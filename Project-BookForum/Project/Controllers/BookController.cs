using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Data.Entities;
using Project.Data.Entities.Account;
using Project.Models.Book;
using Project.Models.Comment;
using Project.Models.Genre;
using Project.Services;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Project.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly BookService bookService;
        private readonly CommonService commonService;
        private readonly CommentService commentService;
        private string? GetUserId() => this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public BookController(ApplicationDbContext context,UserManager<ApplicationUser> _userManager, BookService bookService, CommonService commonService, CommentService commentService)
        {
            this.bookService = bookService;
            userManager = _userManager;
            this.data = context;
            this.commonService = commonService;
            this.commentService = commentService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create(int id)
        {
            BookFormModel model = bookService.GetModelCreate(id);
            ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookFormModel model)
        {
            ApplicationUser currentUser = commonService.FindUser(User);
            ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            bookService.Add(currentUser, model);
            return RedirectToAction("All", "Genre");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book book = data.Book.Find(id);
            this.ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User)); 
            if (commonService.OwnerName(commonService.FindUser(User)) != book.Owner)
            {
                return Unauthorized();
            }
            return View(bookService.GetModel(book));
        }
        [HttpPost]
        public IActionResult Edit(BookFormModel model)
        {
            Book book = data.Book.Find(model.Id);
            this.ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            bookService.Update(book, model);
            return RedirectToAction("All", "Genre");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Book book = data.Book.Find(id);
            this.ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            if (commonService.OwnerName(commonService.FindUser(User)) != book.Owner)
            {
                return Unauthorized();
            }
            return View(bookService.GetModel(book));
        }
        [HttpPost]
        public IActionResult Delete(BookFormModel model)
        {
            Book book = data.Book.Find(model.Id);
            this.ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            if (commonService.OwnerName(commonService.FindUser(User)) != book.Owner)
            {
                return Unauthorized();
            }
            bookService.Delete(book);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Details(int id)
        {
            var comments = commentService.GetComments(id);
            var book = bookService.Details(id, comments);
            if (commonService.FindUser(User) != null)
            {
                ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            }
            if (book == null)
            {
                return BadRequest();
            }
            return View(book);
        }
    }
}
