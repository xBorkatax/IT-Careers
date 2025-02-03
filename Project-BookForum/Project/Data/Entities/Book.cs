using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Data.Entities.Account;

namespace Project.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public Genre ?Genre { get; set; }
        [Required]
        [MinLength(10)]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        [MinLength(10)]
        public string Author { get; set; }
        public string? Owner { get; set; }
        public ApplicationUser ?User { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
