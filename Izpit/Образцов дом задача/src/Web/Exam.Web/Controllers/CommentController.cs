using Exam.Data.Models;
using Exam.Service;
using Exam.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentService commentService;
        private readonly CommonService commonService;
        public CommentController(CommentService _commentService, CommonService commonService)
        {
            this.commentService = _commentService;
            this.commonService = commonService;
        }
        [HttpGet]
        public IActionResult CreateComment(int titleId)
        {
            ViewBag.TitleId = titleId;
            var model = new CommentFormModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(int titleId, CommentFormModel model)
        {
            User user = commonService.FindUser(User);

            model.CreatedById = user.Id;
            model.TitleId = titleId;
            commentService.Create(model);
            string url = $"https://localhost:7212/Title/Details?titleId={titleId}";
            return Redirect(url);
        }
    }
}
