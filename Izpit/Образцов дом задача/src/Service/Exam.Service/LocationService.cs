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
	public class LocationService
	{
		private readonly ExamDbContext context;
		public LocationService(ExamDbContext _context)
		{
			context = _context;
		}
		public async Task Create(LocationFormModel model)
		{
			Location location = new Location()
			{
				Name = model.Name,
				Address = model.Address,
				CreatedById = model.CreatedById,
				CreatedBy = context.Users.Where(x => x.Id == model.CreatedById).FirstOrDefault()
			};
            context.Locations.Add(location);
            context.SaveChanges();
        }
		public async Task<List<LocationViewModel>> GetAllByUserId(int userId)
		{
			return context.Locations.Where(x => x.CreatedById == userId)
			.Select(x => new LocationViewModel
			{
				Id = x.Id,
				Name = x.Name,
				Address = x.Address,
			}).ToList();
		}
		public async Task<List<LocationViewModel>> GetAll()
		{
			return context.Locations.Select(x => new LocationViewModel
			{
				Id = x.Id,
				Name = x.Name,
				Address = x.Address,
				CreatedBy = x.CreatedBy,
			}).ToList();
		}
        public async Task<LocationEditModel> GetModelForEdit(int locationId)
        {
            return await context.Locations.Where(x => x.Id == locationId).Select(x => new LocationEditModel
            {
                Id = x.Id,
                Name = x.Name,
				Address = x.Address,
				CreatedById = x.CreatedById
            }).FirstOrDefaultAsync();
        }
        public async Task<LocationEditModel> Edit(LocationEditModel model)
        {
            var location = await context.Locations.FindAsync(model.Id);
            location.Name = model.Name;
            location.Address = model.Address;
            await context.SaveChangesAsync();
            return model;
        }
        public void Delete(int id)
        {
			var tasks = context.Tasks.Where(x => x.LocationId == id);
			if (!tasks.Any())
			{
				var location = context.Locations.Where(x => x.Id == id).FirstOrDefault();
				context.Locations.Remove(location);
				context.SaveChanges();
			}
        }
    }
}
