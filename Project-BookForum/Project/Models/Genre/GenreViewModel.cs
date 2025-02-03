using Project.Data.Entities;
using Project.Models.Book;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.Genre
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public IEnumerable<BookFormModel> Book { get; set; }
            = new List<BookFormModel>();
    }
}
