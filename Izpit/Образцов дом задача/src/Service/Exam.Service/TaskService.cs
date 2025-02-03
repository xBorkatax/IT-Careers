using Exam.Data;
using Exam.Data.Models;
using Exam.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Exam.Service
{
    public class TaskService
    {
        private readonly ExamDbContext context;
        public TaskService(ExamDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TaskViewModel>> GetAllByUserId(int userId)
        {
            return await context.Tasks.Where(x => x.CreatedById == userId).Select(x => new TaskViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                LocationId = x.LocationId,
                EndDate = x.EndDate,
                Budget = x.Budget,
                CategoryId = x.CategoryId,
                StatusId = x.StatusId,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
            }).ToListAsync();
        }
        public async Task Create(TaskFormModel model)
        {
            Data.Models.Task task = new Data.Models.Task()
            {
                Name = model.Name,
                Description = model.Description,
                LocationId = model.LocationId,
                EndDate = model.EndDate,
                Budget = model.Budget,
                CategoryId = model.CategoryId,
                StatusId = model.StatusId,
                CreatedById = model.CreatedById,
                CreatedBy = context.Users.Where(x => x.Id == model.CreatedById).FirstOrDefault(),
            };
            context.Tasks.Add(task);
            context.SaveChangesAsync();
        }
		public void CancelTask(int taskId)
        {
			var task = context.Tasks.Where(x => x.Id == taskId).FirstOrDefault();
			task.StatusId = 5;
            context.Tasks.Update(task);
			context.SaveChanges();
		}
        public async Task<TaskEditModel> GetModelForEdit(int taskId)
        {
            return await context.Tasks.Where(x => x.Id == taskId).Select(x => new TaskEditModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                LocationId = x.LocationId,
                EndDate = x.EndDate,
                Budget = x.Budget,
                CategoryId = x.CategoryId,
                CreatedById = x.CreatedById,
            }).FirstOrDefaultAsync();
        }
        public async Task<TaskEditModel> Edit(TaskEditModel model)
        {
            var task = await context.Tasks.FindAsync(model.Id);
            task.Name = model.Name;
            task.Description = model.Description;
            task.LocationId = model.LocationId;
            task.EndDate = model.EndDate;
            task.Budget = model.Budget;
            task.CategoryId = model.CategoryId;
            await context.SaveChangesAsync();
            return model;
        }
    }
}
