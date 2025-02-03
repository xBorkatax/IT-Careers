using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data.Entities.Account;
using Project.Data.Entities;
using Project.Data;
using Project.Models.Book;
using System.Security.Claims;
using Project.Models.Comment;
using Microsoft.AspNetCore.Authorization;
using Project.Services;

namespace Project.Controllers
{
    public class CommentController : Controller
    {

        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly CommonService commonService;
        private readonly CommentService commentService;
        private string? GetUserId() => this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public CommentController(ApplicationDbContext context, UserManager<ApplicationUser> _userManager, CommonService commonService, CommentService commentService)
        {
            userManager = _userManager;
            this.data = context;
            this.commonService = commonService;
            this.commentService = commentService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create(int id)
        {
            CommentViewModel model = commentService.GetModelForCreate(id);
            ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CommentViewModel model)
        {
            string owner = commonService.OwnerName(commonService.FindUser(User));
            ApplicationUser user = commonService.FindUser(User);
            commentService.Add(model, owner, user);
            ViewBag.Owner = owner;
            return RedirectToAction("All", "Genre");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Comment comment = data.Comments.Find(id);
            string ownerName = commonService.OwnerName(commonService.FindUser(User));
            this.ViewBag.Owner = ownerName;
            if (ownerName != comment.Owner)
            {
                return Unauthorized();
            }
            return View(commentService.GetModelForEditAndDelete(comment));
        }
        [HttpPost]
        public IActionResult Edit(CommentViewModel model)
        {
            Comment comment = data.Comments.Find(model.Id);
            string ownerName = commonService.OwnerName(commonService.FindUser(User));
            this.ViewBag.Owner = ownerName;
            commentService.Edit(comment, model);
            return RedirectToAction("All", "Genre");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Comment comment = data.Comments.Find(id);
            string ownerName = commonService.OwnerName(commonService.FindUser(User));
            this.ViewBag.Owner = ownerName;
            if (ownerName != comment.Owner)
            {
                return Unauthorized();
            }
            return View(commentService.GetModelForEditAndDelete(comment));
        }
        [HttpPost]
        public IActionResult Delete(CommentViewModel model)
        {
            Comment comment = data.Comments.Find(model.Id);
            string ownerName = commonService.OwnerName(commonService.FindUser(User));
            this.ViewBag.Owner = ownerName;
            commentService.Delete(comment);
            return RedirectToAction("Index", "Home");
        }
    }
}
