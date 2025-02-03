using Exam.Data.Models;
using Exam.Data;
using Exam.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service
{
    public class CommentService
    {
        private readonly ExamDbContext context;
        public CommentService(ExamDbContext _context)
        {
            context = _context;
        }
        public async Task<List<CommentViewModel>> GetAllById(int titleId)
        {
            return context.Comments.Where(x => x.TitleId == titleId)
            .Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
            }).ToList();
        }

        public void Create(CommentFormModel model)
        {
            Comment comment = new Comment()
            {
                Name = model.Name,
                Description = model.Description,
                TitleId = model.TitleId,
                CreatedById = model.CreatedById,
                CreatedBy = context.Users.Where(x => x.Id == model.CreatedById).FirstOrDefault()
            };
            context.Comments.Add(comment);
            context.SaveChanges();
        }
    }
}
