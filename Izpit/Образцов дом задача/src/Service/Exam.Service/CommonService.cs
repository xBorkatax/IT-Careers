using Exam.Data;
using Exam.Data.Models;
using Exam.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service
{
    public class CommonService
    {
        private readonly ExamDbContext context;
		private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
		public CommonService(ExamDbContext _context, UserManager<User> _userManager, RoleManager<Role> _roleManager)
        {
            context = _context;
			userManager = _userManager;
            roleManager = _roleManager;
		}
        public User FindUser(ClaimsPrincipal user)
        {
            string userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return context.Users.Where(x => x.Id == int.Parse(userId))
                .Select(x => new User
                {
                    Id = x.Id,
                    Email = x.Email,
                    UserName = x.UserName,
                })
                .FirstOrDefault();
        }
		public async Task<User> GetUserById(int id)
		{
			var user = userManager.Users
				.Where(user => user.Id == id)
				.FirstOrDefault();

			return user;
		}
		public async Task<List<User>> GetAllUsersAsync()
		{
		    var users = await userManager.Users
		        .ToListAsync();

		    return users;
		}

		public async System.Threading.Tasks.Task EditUser(EditUserViewModel model, ClaimsPrincipal currentUser)
		{
			var userInfo = await userManager.GetUserAsync(currentUser);
			var userToEdit = await context.Users.FindAsync(model.Id);
			if (userToEdit == null)
			{
				throw new Exception("Потребителят не е намерен");
			}

			var isAdmin = await userManager.IsInRoleAsync(userInfo, "Admin");

			if (userInfo.Id == model.Id || isAdmin)
			{	
				userToEdit.Email = model.Email;
				userToEdit.UserName = model.UserName;
				userToEdit.FirstName = model.FirstName;
				userToEdit.LastName = model.LastName;

				var result = await userManager.UpdateAsync(userToEdit);

				if (!result.Succeeded)
				{
					throw new Exception("Грешка, не можа да се запази");
				}
			}
			else
			{
				throw new UnauthorizedAccessException("Нямаш права");
			}
		}
        public async Task<List<LocationViewModel>> GetAllLocations()
        {
            return await context.Locations.Select(x => new LocationViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            }).ToListAsync();
        }
        public async Task<List<LocationViewModel>> GetAllLocationsByUserId(User user)
		{
			return await context.Locations.Where(x => x.CreatedBy.Id == user.Id).Select(x => new LocationViewModel
            {
                Id = x.Id,
				Name = x.Name,
				Address = x.Address
            }).ToListAsync();
        }
   //     public async Task<LocationViewModel> GetLocationsById(int categoryId)
   //     {
			//return await context.Locations.Where(x => x.Id == categoryId).Select(x => new LocationViewModel
			//{
			//	Id = x.Id,
			//	Name = x.Name,
			//	Address = x.Address
			//}).FirstOrDefaultAsync();
   //     }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            return await context.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
				CategoryName = x.CategoryName,
            }).ToListAsync();
        }
        public async Task<List<StatusModel>> AllStatuses()
        {
            return await context.Statuses.Select(x => new StatusModel
            {
                Id = x.Id,
                StatusName = x.StatusName,
            }).ToListAsync();
        }
    }
}
