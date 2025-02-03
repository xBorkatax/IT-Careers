using Project.Data.Entities.Account;
using System.ComponentModel.DataAnnotations;

namespace Project.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string ?Name { get; set; }
        [Required]
        public string ?Description { get; set; }
        public string? Owner { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<Book> Books { get; set; } 
            = new List<Book>();
    }
}
