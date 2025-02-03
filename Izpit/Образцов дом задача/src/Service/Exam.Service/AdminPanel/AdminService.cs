using Exam.Data;
using Exam.Data.Models;
using Exam.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Exam.Service.AdminPanel
{
    public class AdminService
    {
        private readonly CommonService commonService;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ExamDbContext context;

        public AdminService(UserManager<User> _userManager, RoleManager<Role> _roleManager, ExamDbContext _context )
        {
            userManager = _userManager;
            roleManager = _roleManager;
            context = _context;
        }
        public async Task<List<UserDetailsViewModel>> GetAllUsersAsync()
        {
			return await context.Users
			.Select(user => new UserDetailsViewModel
			{
				Id = user.Id,
				UserName = user.UserName,
				FirstName = user.FirstName,
				LastName = user.LastName,
				IsBanned = user.IsBanned,
			})
			.ToListAsync();
		}
        public async Task<int> GetUserCount()
        {
            return context.Users.Count();
        }
		public async Task<int> GetAdminCount()
		{
			var adminRole = await roleManager.FindByNameAsync("Admin");
			if (adminRole == null)
			{
				return 0;
			}

			var usersInAdminRole = await userManager.GetUsersInRoleAsync("Admin");
			return usersInAdminRole.Count;
		}

		public async System.Threading.Tasks.Task BanUser(int userId)
		{
			var user = await context.Users.FindAsync(userId);
			if (user == null)
			{
				throw new Exception("User not found");
			}
			user.IsBanned = true;
			context.Users.Update(user);
			await context.SaveChangesAsync();
			await userManager.UpdateSecurityStampAsync(user);
		}

		public async System.Threading.Tasks.Task UnbanUser(int userId)
		{
			var user = await context.Users.FindAsync(userId);
			if (user == null)
			{
				throw new Exception("User not found");
			}
			user.IsBanned = false;
			context.Users.Update(user);
			await context.SaveChangesAsync();
			await userManager.UpdateSecurityStampAsync(user);
		}
		public async System.Threading.Tasks.Task DeleteUser(int userId)
		{
			var user = await context.Users.FindAsync(userId);
			if (user != null)
			{
				context.Users.Remove(user);
				await context.SaveChangesAsync();
			}
		}

		public async System.Threading.Tasks.Task CreateUser(RegisterViewModel model)
		{
            var user = new User()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //IdentityResult roleResult;
                //if (!(await roleManager.RoleExistsAsync("User")))
                //{
                //    roleResult = await roleManager.CreateAsync(new Role("User"));
                //}
                await userManager.AddToRoleAsync(user, "User");

            }
			else
			{
                throw new Exception("Error");
            }
        }

        public async Task<List<TaskViewModel>> GetAllTasks()
        {
            return await context.Tasks.Select(x => new TaskViewModel
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

        public void DeleteLocation(int id)
        {
            var location = context.Locations.Where(x => x.Id == id).FirstOrDefault();
            context.Locations.Remove(location);
            context.SaveChanges();
        }
        public void DeleteTask(int id)
        {
            var task = context.Tasks.Where(x => x.Id == id).FirstOrDefault();
            context.Tasks.Remove(task);
            context.SaveChanges();
        }

        //public async Task DeleteUserSoft(int userId)
        //{
        //	var user = await context.Users.FindAsync(userId);
        //	if (user != null)
        //	{
        //		user.IsDeleted = true;
        //		await context.SaveChangesAsync();
        //	}
        //}

    }
}
