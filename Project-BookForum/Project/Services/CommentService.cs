using Project.Data;
using Project.Data.Entities;
using Project.Data.Entities.Account;
using Project.Models.Book;
using Project.Models.Comment;

namespace Project.Services
{
    public class CommentService
    {
        ApplicationDbContext context;
        public IEnumerable<CommentViewModel> GetComments(int id) => context.Comments.Where(x => x.BookId == id).Select(x => new CommentViewModel()
        {
            Id = x.Id,
            Description = x.Description,
            BookId = x.BookId,
            Owner = x.Owner,
        }).ToList();
        private BookFormModel GetBook(int id)
            => context.Book.Where(x => x.Id == id).Select(x => new BookFormModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).FirstOrDefault();
        public CommentService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public CommentViewModel GetModelForCreate(int id)
        {
            CommentViewModel model = new CommentViewModel()
            {
                Book = GetBook(id),
                BookId = id
            };
            return model;
        }
        public void Add(CommentViewModel model, string ownerName, ApplicationUser user)
        {
            Comment comment = new Comment()
            {
                Description = model.Description,
                User = user,
                Owner = ownerName,
                BookId = (int)model.BookId,
                Book = context.Book.FirstOrDefault(x => x.Id == model.BookId)
            };
            context.Comments.Add(comment);
            context.SaveChanges();
        }
        public CommentViewModel GetModelForEditAndDelete(Comment comment)
        {
            CommentViewModel bookViewModel = new CommentViewModel()
            {
                Id = comment.Id,
                Description = comment.Description,
                BookId= comment.BookId,
                Book = GetBook(comment.Id)
            };
            return bookViewModel;
        }
        public void Edit(Comment comment, CommentViewModel model)
        {
            comment.Description = model.Description;
            context.SaveChanges();
        }
        public void Delete(Comment comment) 
        {
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}
