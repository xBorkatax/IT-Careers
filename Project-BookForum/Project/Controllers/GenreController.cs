using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using Mysqlx.Crud;
using Project.Data;
using Project.Data.Entities;
using Project.Data.Entities.Account;
using Project.Models;
using Project.Models.Book;
using Project.Models.Genre;
using Project.Services;
using System.Security.Claims;

namespace Project.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly GenreService genreService;
        private readonly CommonService commonService;
        private string? GetUserId() => this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public GenreController(ApplicationDbContext data, CommonService commonService, GenreService genreService)
        {
            this.data = data;
            this.commonService = commonService;
            this.genreService = genreService;
        }

        public IActionResult All()
        {
            if (commonService.FindUser(User) != null) {
                ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            }
            var genres = genreService.GetAllGenres();
            
            return View(genres);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            GenreViewModel model = new GenreViewModel() { };
            ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(GenreViewModel model)
        {
            ApplicationUser currentUser = commonService.FindUser(User);
            string ownerName = commonService.OwnerName(currentUser);
            ViewBag.Owner = ownerName;
            genreService.Add(model, ownerName, currentUser);
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Genre genre = data.Genres.Find(id);
            string ownerName = commonService.OwnerName(commonService.FindUser(User));
            this.ViewBag.Owner = ownerName;
            if (!genreService.CheckIfOwner(ownerName, genre))
            {
                return Unauthorized();
            }
            return View(genreService.GetModel(genre));
        }
        [HttpPost]
        public IActionResult Edit(GenreViewModel model)
        {
            Genre genre = data.Genres.Find(model.Id);
            this.ViewBag.Owner = commonService.OwnerName(commonService.FindUser(User));
            genre.Name = model.Name;
            genre.Description = model.Description;
            this.data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Genre genre = this.data.Genres.Find(id);
            string ownerName = commonService.OwnerName(commonService.FindUser(User));
            if (!genreService.CheckIfOwner(ownerName, genre))
            {
                return Unauthorized();
            }
            GenreViewModel genreViewModel = genreService.GetModel(genre);
            this.ViewBag.Owner = ownerName;
            return View(genreViewModel);
        }
        [HttpPost]
        public IActionResult Delete(GenreViewModel model)
        {
            string ownerName = commonService.OwnerName(commonService.FindUser(User));
            this.ViewBag.OwnerName = ownerName;
            this.data.Genres.Remove(this.data.Genres.Find(model.Id));
            this.data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int id)
        {
            if (GetUserId() != null)
            {
                var owner = GetUserId();
                ApplicationUser currentUser = this.data.Users.Find(owner);
                this.ViewBag.Owner = currentUser.FirstName + " " + currentUser.LastName;
            }
            var view = genreService.Details(id);
            return View(view);
        }

    }
}
