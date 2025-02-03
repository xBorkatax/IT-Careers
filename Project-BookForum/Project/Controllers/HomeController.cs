using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Data.Entities;
using Project.Data.Entities.Account;
using Project.Models;
using Project.Models.Book;
using Project.Models.Genre;
using Project.Models.Home;
using System.Diagnostics;
using System.Security.Claims;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext data;
        private string? GetUserId() => this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.data = context;
        }

        public async Task<IActionResult> Index()
        {
            //var genres = await this.data.Genres.Select(g => g.Name).Distinct().ToListAsync();
            //var bookCount = new List<HomeGenreModel>();
            //foreach (var genre in genres)
            //{
            //    var countOfBooks = this.data.Book.Where(b => b.Genre.Name == genre).Count();
            //    Genre currentGenre = this.data.Genres.Where(g => g.Name == genre).FirstOrDefault();
            //    bookCount.Add(new HomeGenreModel()
            //    {
            //        GenreName = genre,
            //        BookCount = countOfBooks,
            //        GenreId = currentGenre.Id
            //    });
            //}
            //var homeModel = new HomeViewModel()
            //{
            //    AllBookCount = this.data.Book.Count(),
            //    AllBooks = bookCount
            //};
            //return View(homeModel);
            var genres = this.data.Genres
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    Book = g.Books.Select(b => new BookFormModel()
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Description = b.Description,
                        Owner = b.Owner
                    })
                })
                .ToList();
            var owner = GetUserId();
            if (owner != null)
            {
                ApplicationUser currentUser = this.data.Users.Find(owner);
                this.ViewBag.Owner = currentUser.FirstName + " " + currentUser.LastName;
            }
            return View(genres);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}