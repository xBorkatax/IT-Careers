using Project.Models.Book;

namespace Project.Models.Genre
{
    public class GenreDetailsViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Owner { get; set; }
        public IEnumerable<BookFormModel> Books { get; set; }
    }
}
