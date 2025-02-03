using Exam.Data;
using Exam.Data.Models;
using Exam.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Service
{
    public class BarberService
    {
        private readonly ExamDbContext context;
        public BarberService(ExamDbContext _context)
        {
            context = _context;
        }
        public async Task<List<BarberViewModel>> GetAll()
        {
            return context.Barbers.Select(x => new BarberViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
                ImageUrl = x.ImageUrl,
            }).ToList();
        }

        public async Task Create(BarberFormModel model) 
        {
            Barber barber = new Barber()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedById = model.CreatedById,
                CreatedBy = context.Users.Where(x => x.Id == model.CreatedById).FirstOrDefault(),
                ImageUrl = model.ImageUrl,
            };
            context.Barbers.Add(barber);
            context.SaveChanges();
        }
        public async Task<BarberViewModel> GetById(int id)
        {
            return context.Barbers.Where(x => x.Id == id).Select(x => new BarberViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
                ImageUrl = x.ImageUrl,
            }).FirstOrDefault();
        }
        public async Task<BarberEditModel> GetByIdForEdit(int id)
        {
            return context.Barbers.Where(x => x.Id == id).Select(x => new BarberEditModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
                ImageUrl = x.ImageUrl,
            }).FirstOrDefault();
        }
        public async Task<BarberEditModel> Edit(BarberEditModel model)
        {
            var barber = await context.Barbers.FindAsync(model.Id);
            if (barber == null)
            {
                throw new KeyNotFoundException("Barber not found");
            }

            barber.Name = model.Name;
            barber.Description = model.Description;

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
                barber.ImageUrl = model.ImageUrl;
            }

            await context.SaveChangesAsync();
            return model;
        }
        public void Delete(int id)
        {
            var barber = context.Barbers.Where(x => x.Id == id).FirstOrDefault();  
            context.Barbers.Remove(barber);
            context.SaveChanges();
        }

        public async Task<List<BarberViewModel>> SearchByName(string searchString)
        {
            return await context.Barbers
                .Where(t => t.Name.Contains(searchString))
                .Select(t => new BarberViewModel
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
