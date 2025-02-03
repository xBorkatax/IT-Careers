using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Project.Controllers;
using Project.Data;
using Project.Data.Entities;
using Project.Data.Entities.Account;
using Project.Models.Genre;
using Project.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Project.Tests.Controllers
{
    public class GenreServiceTest
    {
        private ApplicationDbContext dbContext;
        private GenreService genreService;
        private CommonService commonService;
        private GenreController genreController;
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private ApplicationUser testUser;

        [SetUp]
        public async Task Setup()
        {
            
            dbContext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options);
            genreService = new GenreService(dbContext);
        }

        [Test]
        public void GetAllGenres_ReturnsAllGenres()
        {
           
            dbContext.Genres.AddRange(new List<Genre>
            {
                new Genre { Id = 1, Name = "Genre 1", Description= "slkjbacjkakc" },
                new Genre { Id = 2, Name = "Genre 2", Description= "slkjbacjkakc" },
                new Genre { Id = 3, Name = "Genre 3" , Description = "slkjbacjkakc"}
            });
            dbContext.SaveChanges();

           
            var genres = genreService.GetAllGenres();

            
            Assert.AreEqual(3, genres.Count);
            Assert.AreEqual("Genre 1", genres[0].Name);
            Assert.AreEqual("Genre 2", genres[1].Name);
            Assert.AreEqual("Genre 3", genres[2].Name);
        }

        [Test]
        public void CreateGenre_AddsNewGenre()
        {
         
            var model = new GenreViewModel { Name = "New Genre", Description = "Genre Description" };
            var user = new ApplicationUser { Id = "1", UserName = "testuser",
                FirstName="Test", LastName="Testov" };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();


            genreService.Add(model, user.FirstName + " "+ user.LastName, user);

          
            var genre = dbContext.Genres.FirstOrDefault(x => x.Name == "New Genre");
            Assert.IsNotNull(genre);
            Assert.AreEqual("New Genre", genre.Name);
            Assert.AreEqual(user.Id, genre.User.Id);
        }
        [Test]
        public void GetGenre_ReturnsCorrectGenre()
        {
            var model = new GenreViewModel { Id = 1,Name = "New Genre", Description = "Genre Description" };
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser",
                FirstName = "Test",
                LastName = "Testov"
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            genreService.Add(model, user.FirstName + " " + user.LastName, user);

            var actualModel = genreService.GetGenre(model.Id);
            Assert.IsNotNull(actualModel);
        }
        [Test]
        public void GetAllBooksById_ReturnsCorrectBooks()
        {
            var model = new Genre { Id = 1, Name = "New Genre", Description = "Genre Description" };
            dbContext.Genres.Add(model); 
            dbContext.SaveChanges();
            dbContext.Book.AddRange(new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Description= "slkjbacjkakc", GenreId = model.Id, Author = "ajjaxlxa"},
                new Book { Id = 2, Title = "Book 2", Description= "slkjbacjkakc", GenreId = model.Id, Author = "ajjaxlxa"},
                new Book { Id = 3, Title = "Book 3", Description = "slkjbacjkakc", GenreId = model.Id, Author = "ajjaxlxa"}
            });
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser",
                FirstName = "Test",
                LastName = "Testov"
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var actualModel = genreService.GetAllBooksById(model.Id);
            Assert.IsNotNull(actualModel);
        }
        [Test]
        public void GetModel_ReturnsModel()
        {
            var model = new Genre { Id = 1, Name = "New Genre", Description = "Genre Description" };
            dbContext.Genres.Add(model);
            dbContext.SaveChanges();
            var actualModel = genreService.GetModel(model);
            Assert.IsNotNull(actualModel);
        }
        [Test]
        public void CheckIfOwner_TrueCase()
        {
            var model = new Genre { Id = 1, Name = "New Genre", Description = "Genre Description", Owner = "Test" };
            dbContext.Genres.Add(model);
            dbContext.SaveChanges();
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser",
                FirstName = "Test",
                LastName = "Testov"
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            var actualModel = genreService.CheckIfOwner(user.FirstName, model);
            Assert.IsTrue(actualModel);
        }
        [Test]
        public void CheckIfOwner_FalseCase()
        {
            var model = new Genre { Id = 1, Name = "New Genre", Description = "Genre Description", Owner = "Test1" };
            dbContext.Genres.Add(model);
            dbContext.SaveChanges();
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser",
                FirstName = "Test",
                LastName = "Testov"
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            var actualModel = genreService.CheckIfOwner(user.FirstName, model);
            Assert.IsFalse(actualModel);
        }
        [Test]
        public void GenreDetails_ReturnGenreModel()
        {
            var model = new Genre { Id = 1, Name = "New Genre", Description = "Genre Description", Owner = "Test1" };
            dbContext.Genres.Add(model);
            dbContext.SaveChanges();
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser",
                FirstName = "Test",
                LastName = "Testov"
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            var actualModel = genreService.Details(model.Id);
            Assert.IsNotNull(actualModel);
        }
    }
}