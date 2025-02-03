using Microsoft.Build.Framework;
using Project.Data.Entities.Account;
using Project.Models.Comment;
using Project.Models.Genre;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.Book
{
    public class BookFormModel
    {
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MinLength(10)]
        public string? Title { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MinLength(10)]

        public string? Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MinLength(10)]
        public string Author { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public ApplicationUser? User { get; set; }
        public string Owner { get; set; }
        public GenreViewModel Genre { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
