using Microsoft.AspNetCore.Authorization;
using Project.Data.Entities.Account;
using System.ComponentModel.DataAnnotations;

namespace Project.Data.Entities
{

    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        public string ?Description { get; set; }
        public int BookId { get; set; }
        public Book ?Book { get; set; }
        public string? Owner { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
