using Project.Data.Entities.Account;
using Project.Models.Book;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Description { get; set; }
        [Display(Name = "Books")]
        public int BookId { get; set; }
        public string Owner { get; set; }
        public BookFormModel Book { get; set; }
    }
}
