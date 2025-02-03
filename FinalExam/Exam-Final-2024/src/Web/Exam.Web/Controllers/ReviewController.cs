using Exam.Data.Models;
using Exam.Service;
using Exam.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService reviewService;
        private readonly CommonService commonService;
        public ReviewController(ReviewService _reviewService, CommonService commonService)
        {
            this.reviewService = _reviewService;
            this.commonService = commonService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateReview(int barberId)
        {
            ViewBag.BarberId = barberId;
            var model = new ReviewFormModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReview(int barberId, ReviewFormModel model)
        {
            User user = commonService.FindUser(User);

            model.CreatedById = user.Id;
            model.BarberId = barberId;
            reviewService.Create(model);
            string url = $"https://localhost:7212/Barber/Details?titleId={barberId}";
            return Redirect(url);
        }

        [Authorize]
        public IActionResult Delete(int reviewId, int barberId)
        {
            reviewService.Delete(reviewId);
            string url = $"https://localhost:7212/Barber/Details?titleId={barberId}";
            return Redirect(url);
        }

        [Authorize]
        public IActionResult DeleteInMyReviews(int reviewId)
        {
            reviewService.Delete(reviewId);
            User user = commonService.FindUser(User);
            string url = $"https://localhost:7212/Review/MyReviews?userId={user.Id}";
            return Redirect(url);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            ReviewEditModel model = await reviewService.GetByIdForEdit(id);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(ReviewEditModel model)
        {
            if (model.Name != null && model.Description != null) 
            {
                await reviewService.Edit(model);
                string url = $"https://localhost:7212/Barber/Details?titleId={model.BarberId}";
                return Redirect(url);
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyReviews(int userId)
        {
            User user = commonService.FindUser(User);
            if (user.Id == userId) 
            { 
                List<ReviewViewModel> model = await reviewService.GetAllByUserId(userId);
                return View(model);
            }
            else
            {
                return Redirect("https://localhost:7212/Account/Error");
            }
        }

        public IActionResult Locate(int barberId)
        {
            string url = $"https://localhost:7212/Barber/Details?titleId={barberId}";
            return Redirect(url);
        }
    }
}
