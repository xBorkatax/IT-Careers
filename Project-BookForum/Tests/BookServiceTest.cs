using NUnit.Framework;
using Project.Data;
using Project.Data.Entities;
using Project.Data.Entities.Account;
using Project.Models.Book;
using Project.Models.Comment;
using Project.Models.Genre;
using Project.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project.Tests.Services
{
    [TestFixture]
    public class BookServiceTests
    {
        private ApplicationDbContext _context;
        private BookService _bookService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);

            _bookService = new BookService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public void GetGenres_ReturnsAllGenres()
        {
            
            var expectedGenres = new List<GenreViewModel>()
        {
            new GenreViewModel { Id = 1, Name = "Science Fiction", Description = "Stories with futuristic or imaginary science and technology" },
            new GenreViewModel { Id = 2, Name = "Romance", Description = "Stories about romantic love" }
        };

            var genre1 = new Genre { Id = 1, Name = "Science Fiction", Description = "Stories with futuristic or imaginary science and technology" };
            var genre2 = new Genre { Id = 2, Name = "Romance", Description = "Stories about romantic love" };
            _context.Genres.AddRange(genre1, genre2);
            _context.SaveChanges();

            
            var result = _bookService.GetGenres();

            
            Assert.AreEqual(expectedGenres.Count, result.Count());
            foreach (var expectedGenre in expectedGenres)
            {
                Assert.IsTrue(result.Any(g => g.Id == expectedGenre.Id && g.Name == expectedGenre.Name && g.Description == expectedGenre.Description));
            }
        }

        [Test]
        public void GetGenre_ReturnsCorrectGenre()
        {
            
            var expectedGenre = new GenreViewModel { Id = 1, Name = "Science Fiction", Description = "Stories with futuristic or imaginary science and technology" };
            var genre1 = new Genre { Id = 1, Name = "Science Fiction", Description = "Stories with futuristic or imaginary science and technology" };
            var genre2 = new Genre { Id = 2, Name = "Romance", Description = "Stories about romantic love" };
            _context.Genres.AddRange(genre1, genre2);
            _context.SaveChanges();

            
            var result = _bookService.GetGenre(1);

            
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(expectedGenre.Id));
            Assert.That(result.Name, Is.EqualTo(expectedGenre.Name));
            Assert.That(result.Description, Is.EqualTo(expectedGenre.Description));
        }
        [Test]
        public void GetAllBooksById_ReturnCorrectBooks()
        {
            var genre1 = new Genre { Id = 1, Name = "Science Fiction", Description = "Stories with futuristic or imaginary science and technology" };
            var book = new Book { Id = 1, Author = "Test", Description = "Description 1", Title = "LSLSLS", GenreId = 2 };
            var book2 = new Book { Id = 2, Author = "Test", Description = "Description 1", Title = "LSLSLS", GenreId = 2 };
            _context.Genres.Add(genre1);
            _context.Book.Add(book);
            _context.Book.Add(book2);
            var actualBooks = _bookService.GetAllBooksById(genre1.Id);
            Assert.That(actualBooks.Count()==0);
        }
        [Test]
        public void GetModelCreate_ReturnModel()
        {
            var genre1 = new Genre { Id = 1, Name = "Science Fiction", Description = "Stories with futuristic or imaginary science and technology" };
            _context.Genres.Add(genre1);
            var actualBooks = _bookService.GetModelCreate(genre1.Id);
            Assert.IsNotNull(actualBooks);
        }
        [Test]
        public void GetModel_ReturnModel()
        {
            var book = new Book { Id = 1, Author = "Test", Description = "Description 1", Title = "LSLSLS", GenreId = 2 }; 
            var actualBooks = _bookService.GetModel(book);
            Assert.IsNotNull(actualBooks);
        }
        [Test]
        public void Add_AddModel()
        {
            var book = new BookFormModel { Id = 1, Author = "Test", Description = "Description 1", Title = "LSLSLS", GenreId = 2 };
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser",
                FirstName = "Test",
                LastName = "Testov"
            };
            _context.Users.Add(user);
            _bookService.Add(user, book);
            var model = _bookService.GetAllBooksById(book.Id);
            Assert.IsNotNull(model);
        }
        [Test]
        public void Update_UpdateModel()
        {
            var book = new Book { Id = 1, Author = "Test", Description = "Description 1", Title = "LSLSLS", GenreId = 2 };
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser",
                FirstName = "Test",
                LastName = "Testov"
            };
            _context.Users.Add(user);
            _context.Book.Add(book);
            var updatedBook = new BookFormModel { Id = 1, Author = "Test", Description = "Description 2", Title = "LSLSLS", GenreId = 2 };
            _bookService.Update(book, updatedBook);
            var actualModel = _bookService.GetAllBooksById(2).FirstOrDefault();
            Assert.That(actualModel.Description, Is.EqualTo(updatedBook.Description));
        }
        [Test]
        public void Delete_DeleteModel()
        {
            var book = new Book { Id = 1, Author = "Test", Description = "Description 1", Title = "LSLSLS", GenreId = 2 };
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser",
                FirstName = "Test",
                LastName = "Testov"
            };
            _context.Users.Add(user);
            _context.Book.Add(book);
            _bookService.Delete(book);
            var actualModel = _bookService.GetAllBooksById(2).FirstOrDefault();
            Assert.IsNull(actualModel);
        }
        [Test]
        public void Details_DetailsModel()
        {
            var book = new Book { Id = 1, Author = "Test", Description = "Description 1", Title = "LSLSLS", GenreId = 2 };
            var comment = new Comment { Description = "Test", BookId = 1, Id= 1 };
            _context.Comments.Add(comment);
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser",
                FirstName = "Test",
                LastName = "Testov"
            };
            _context.Users.Add(user);
            _context.Book.Add(book);
            var model = _bookService.Details(1, null);
            Assert.IsNull(model);
        }

    }
}