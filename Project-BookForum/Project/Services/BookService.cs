using Project.Data;
using Project.Data.Entities;
using Project.Data.Entities.Account;
using Project.Models.Book;
using Project.Models.Comment;
using Project.Models.Genre;

namespace Project.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext context;
     
        public BookService(ApplicationDbContext context)
        {
            this.context = context;
            
        }
        public IEnumerable<GenreViewModel> GetGenres() => context.Genres.Select(g => new GenreViewModel
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description
        }).ToList();
        public GenreViewModel GetGenre(int Id) => context.Genres.Where(x => x.Id == Id).Select(g => new GenreViewModel
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description
        }).FirstOrDefault();
        public List<BookFormModel> GetAllBooksById(int Id)
        {
            return context.Book.Where(x => x.GenreId == Id).Select(x => new BookFormModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Author = x.Author,
                Owner = x.Owner
            }).ToList();
        }
        public BookFormModel GetModelCreate(int Id)
        {
            return new BookFormModel()
            {
                Genre = GetGenre(Id),
                GenreId = Id
            };
        }
        public BookFormModel GetModel(Book? book)
        {
            var editedBook =  new BookFormModel()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Genres = GetGenres(),
                Genre = GetGenre(book.GenreId),
                Author = book.Author,
                GenreId = book.GenreId
            };
            return editedBook;
        }
        public void Add(ApplicationUser currentUser, BookFormModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                User = currentUser,
                Author = model.Author,
                Owner = $"{currentUser.FirstName} {currentUser.LastName}",
                GenreId = (int)model.GenreId,
                Genre = context.Genres.FirstOrDefault(x => x.Id == model.GenreId)
            };
            context.Book.Add(book);
            context.SaveChanges();
        }
        public void Update(Book book, BookFormModel model)
        {
            book.Title = model.Title;
            book.Description = model.Description;
            book.Author = model.Author;
            book.GenreId = model.GenreId;
            book.Genre = context.Genres.Where(x => x.Id == model.GenreId).FirstOrDefault();
            context.SaveChanges();
        }
        public void Delete(Book book)
        {
            context.Book.Remove(book);
            context.SaveChanges();
        }
        public BookFormModel Details(int Id, IEnumerable<CommentViewModel> comments)
        {
            var book =  context.Book
                .Where(b => b.Id == Id)
                .Select(b => new BookFormModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author = b.Author,
                    Genre = context.Genres.Where(x => x.Id == b.GenreId).Select(g => new GenreViewModel
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Description = g.Description
                    }).FirstOrDefault(),
                    GenreId = b.GenreId,
                    Owner = b.Owner,
                    Comments = comments,
                }).FirstOrDefault();
            return book;
        }
    }
}
