using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Project.Data;
using Project.Data.Entities;
using Project.Models.Book;
using Project.Models.Comment;
using Project.Services;
using System.Linq;
using System.Xml.Linq;

namespace Project.Tests.Services
{
    [TestFixture]
    public class CommentServiceTests
    {
        private CommentService _commentService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new ApplicationDbContext(options);
            _commentService = new CommentService(context);
        }

        [Test]
        public void GetComments_ReturnsCommentsForGivenBookId()
        {
            var bookId = 1;
            var expectedComments = new[]
            {
                new Comment { Id = 1, Description = "Comment 1", Owner = "Owner 1", BookId = bookId },
                new Comment { Id = 2, Description = "Comment 2", Owner = "Owner 2", BookId = bookId },
                new Comment { Id = 3, Description = "Comment 3", Owner = "Owner 3", BookId = bookId }
            };
            foreach (var comment in expectedComments)
            {
                _commentService.Add(new CommentViewModel { Description = comment.Description, BookId = bookId }, comment.Owner, null);
            }

            var actualComments = _commentService.GetComments(bookId);

            Assert.That(actualComments.Count(), Is.EqualTo(expectedComments.Length));
            foreach (var expectedComment in expectedComments)
            {
                var actualComment = actualComments.FirstOrDefault(x => x.Id == expectedComment.Id);
                Assert.That(actualComment, Is.Not.Null);
                Assert.That(actualComment.Description, Is.EqualTo(expectedComment.Description));
                Assert.That(actualComment.Owner, Is.EqualTo(expectedComment.Owner));
            }
        }

        [Test]
        public void GetModelForCreate_ReturnsCommentViewModelWithBook()
        {
            var bookId = 1;
            var expectedBook = new BookFormModel { Id = bookId, Title = "Book 1", Description = "Description 1" };
            _commentService.Add(new CommentViewModel { Description = "Comment 1", BookId = bookId, Book = expectedBook}, "Owner 1", null);
            var actualModel = _commentService.GetModelForCreate(bookId);

            Assert.That(actualModel.BookId, Is.EqualTo(expectedBook.Id));
        }

        [Test]
        public void Add_CreatesNewComment()
        {
            var bookId = 1;
            var model = new CommentViewModel { Description = "New Comment", BookId = bookId };
            var ownerName = "Owner 1";

            // Act
            _commentService.Add(model, ownerName, null);

            // Assert
            var actualComment = _commentService.GetComments(bookId).FirstOrDefault(x => x.Description == model.Description);
            Assert.That(actualComment, Is.Not.Null);
            Assert.That(actualComment.Owner, Is.EqualTo(ownerName));
        }

        [Test]
        public void GetModelForEditAndDelete_ReturnsCommentViewModelWithBook()
        {
            var commentId = 1;
            var expectedBook = new BookFormModel { Id = 1, Title = "Book 1", Description = "Description 1" };
            _commentService.Add(new CommentViewModel { Description = "Comment 1", BookId = 1 }, "Owner 1", null);

            var comment = _commentService.GetComments(1).FirstOrDefault(x => x.Id == commentId);
            var actualModel = _commentService.GetModelForEditAndDelete(new Comment { Id = commentId, Description = comment.Description, BookId = comment.BookId });

            Assert.That(actualModel.Id, Is.EqualTo(1));
            Assert.That(actualModel.BookId, Is.EqualTo(1));
            Assert.That(actualModel.Description, Is.EqualTo("Comment 1"));
        }

        [Test]
        public void Edit_UpdatesCommentDescription()
        {
            var commentId = 1;
            var initialDescription = "Initial Comment";
            var updatedDescription = "Updated Comment";
            _commentService.Add(new CommentViewModel { Id = commentId, Description = initialDescription, BookId = 1 }, "Owner 1", null);

            var comment = _commentService.GetComments(1).FirstOrDefault(x => x.Id == commentId);
            _commentService.Edit(new Comment { Id = commentId, Description = comment.Description, BookId = comment.BookId },
                new CommentViewModel { Description = updatedDescription });

            var actualComment = _commentService.GetComments(1).FirstOrDefault(x => x.Id == commentId);
            Assert.That(actualComment, Is.Not.Null);
            Assert.That(actualComment.Description, Is.EqualTo(initialDescription));
        }
    }
}

