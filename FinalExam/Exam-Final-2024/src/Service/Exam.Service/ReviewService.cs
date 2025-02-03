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
    public class ReviewService
    {
        private readonly ExamDbContext context;
        public ReviewService(ExamDbContext _context)
        {
            context = _context;
        }
        public async Task<List<ReviewViewModel>> GetAllById(int reviewId)
        {
            return context.Reviews.Where(x => x.BarberId == reviewId)
            .Select(x => new ReviewViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
            }).ToList();
        }

        public void Create(ReviewFormModel model)
        {
            Review review = new Review()
            {
                Name = model.Name,
                Description = model.Description,
                BarberId = model.BarberId,
                CreatedById = model.CreatedById,
                CreatedBy = context.Users.Where(x => x.Id == model.CreatedById).FirstOrDefault()
            };
            context.Reviews.Add(review);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var review = context.Reviews.Where(x => x.Id == id).FirstOrDefault();
            context.Reviews.Remove(review);
            context.SaveChanges();
        }
        public async Task<ReviewEditModel> GetByIdForEdit(int id)
        {
            return context.Reviews.Where(x => x.Id == id).Select(x => new ReviewEditModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
                BarberId = x.BarberId
            }).FirstOrDefault();
        }
        public async Task<ReviewEditModel> Edit(ReviewEditModel model)
        {
            var review = await context.Reviews.FindAsync(model.Id);
            review.Name = model.Name;
            review.Description = model.Description;
            await context.SaveChangesAsync();
            return model;
        }

		public async Task<List<ReviewViewModel>> GetAllByUserId(int userId)
		{
			return context.Reviews.Where(x => x.CreatedById == userId)
			.Select(x => new ReviewViewModel
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
                BarberId= x.BarberId
			}).ToList();
		}
	}
}
