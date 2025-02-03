using BarRating.Service.Models;
using BarRating.Service.Review;
using BarRating.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarRating.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewFacade reviewFacade;
        private readonly IReviewService reviewService;

        public ReviewController(IReviewFacade reviewFacade, IReviewService reviewService)
        {
            this.reviewFacade = reviewFacade;
            this.reviewService = reviewService;
        }

        public IActionResult Index(string id)
        {
            return View(reviewService.GetAllByBarId(id));
        }

        public IActionResult Create(string id, string barName)
        {
            ReviewCreationModel reviewCreationModel = new ReviewCreationModel();
            reviewCreationModel.BarName = barName;
            reviewCreationModel.BarId = id;
            return View(reviewCreationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewCreationModel reviewCreationModel)
        {
            if (ModelState.IsValid)
            {
                await reviewFacade.CreateReview(reviewCreationModel);
                return RedirectToAction(nameof(Index), new {id = reviewCreationModel.BarId});
            }

            return View(reviewCreationModel);
        }

        public async Task<IActionResult> MyReviews(string id)
        {
            IEnumerable<ReviewDto> reviews = reviewService.GetAllByUserId(id);

            return View("Index", reviews);
        }
    }
}
