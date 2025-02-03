using Org.BouncyCastle.Asn1.X509;
using Project.Data;
using Project.Data.Entities;
using Project.Data.Entities.Account;
using Project.Models.Book;
using Project.Models.Genre;
using System.Security.Claims;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project.Services
{
    public class GenreService
    {
        private readonly ApplicationDbContext context;

        public GenreService(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public List<BookFormModel> GetAllBooksById(int Id)
        {
            return context.Book.Where(x => x.GenreId == Id).Select(x => new BookFormModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Owner = x.Owner
            }).ToList();
        }
        public GenreViewModel GetGenre(int Id)
            => context.Genres.Where(x => x.Id == Id).Select(x => new GenreViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();
        public List<GenreViewModel> GetAllGenres()
        {
            return this.context.Genres
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
        }
        public void Add(GenreViewModel model, string ownerName, ApplicationUser currentUser)
        {
            Genre genre = new Genre()
            {
                Name = model.Name,
                Description = model.Description,
                Owner = ownerName,
                User = currentUser
            };
            context.Genres.Add(genre);
            context.SaveChanges();
        }
        public GenreViewModel GetModel(Genre genre)
        {
            GenreViewModel genreViewModel = new GenreViewModel()
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
            };
            return genreViewModel;
        }
        public bool CheckIfOwner(string ownerName, Genre genre) 
        {
            if (ownerName != genre.Owner)
            {
                return false;
            }
            return true;
        }
        public GenreDetailsViewModel Details(int id)
        {
            var genre =  context.Genres
                .Where(g => g.Id == id)
                .Select(g => new GenreDetailsViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    Owner = g.Owner,
                    Books = GetAllBooksById(id)
                }).FirstOrDefault();
            return genre;
        }
    }
}
