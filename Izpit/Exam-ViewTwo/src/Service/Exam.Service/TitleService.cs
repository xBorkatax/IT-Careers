using Exam.Data;
using Exam.Data.Models;
using Exam.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service
{
    public class TitleService
    {
        private readonly ExamDbContext context;
        public TitleService(ExamDbContext _context)
        {
            context = _context;
        }
        public async Task<List<TitleViewModel>> GetAll()
        {
            return context.Titles.Select(x => new TitleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
                ImageUrl = x.ImageUrl,
            }).ToList();
        }

        public async Task Create(TitleFormModel model) 
        {
            //byte[] imageContents;
            //using (var memoryStream = new MemoryStream())
            //{
            //    await model.Image.CopyToAsync(memoryStream);
            //    imageContents = memoryStream.ToArray();
            //}
            Title title = new Title()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedById = model.CreatedById,
                CreatedBy = context.Users.Where(x => x.Id == model.CreatedById).FirstOrDefault(),
                ImageUrl = model.ImageUrl,
            };
            context.Titles.Add(title);
            context.SaveChanges();
        }
        public async Task<TitleViewModel> GetById(int id)
        {
            return context.Titles.Where(x => x.Id == id).Select(x => new TitleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
                ImageUrl = x.ImageUrl,
            }).FirstOrDefault();
        }
        public async Task<TitleEditModel> GetByIdForEdit(int id)
        {
            return context.Titles.Where(x => x.Id == id).Select(x => new TitleEditModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
                ImageUrl = x.ImageUrl,
            }).FirstOrDefault();
        }
        public async Task<TitleEditModel> EditById(TitleEditModel model)
        {
            var title = await context.Titles.FindAsync(model.Id);
            if (title == null)
            {
                // Handle the case where the title is not found
                throw new KeyNotFoundException("Title not found");
            }

            // Update properties
            title.Name = model.Name;
            title.Description = model.Description;

            // Handle image upload
            if (model.Image != null)
            {
                string folder = "Photos/";
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(folder, uniqueFileName);

                model.ImageUrl = filePath;

                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder);


                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string fullPath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }
                title.ImageUrl = model.ImageUrl;
            }
            //title.CreatedBy = model.CreatedBy;
            await context.SaveChangesAsync();
            return model;
        }
		public void Delete(int id)
		{
			var title = context.Titles.Where(x => x.Id == id).FirstOrDefault();
			context.Titles.Remove(title);
			context.SaveChanges();
		}

		public async Task<List<TitleViewModel>> SearchByName(string searchString)
        {
            return await context.Titles
                .Where(t => t.Name.Contains(searchString))
                .Select(t => new TitleViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    CreatedBy = t.CreatedBy,
                    ImageUrl = t.ImageUrl
                })
                .ToListAsync();
        }
    }
}
