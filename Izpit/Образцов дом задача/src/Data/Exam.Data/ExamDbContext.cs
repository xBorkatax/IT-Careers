using Exam.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Task = Exam.Data.Models.Task;

namespace Exam.Data
{
	public class ExamDbContext : IdentityDbContext<User, Role, int>
	{
		public ExamDbContext()
			: base()
		{
		}
		public ExamDbContext(DbContextOptions<ExamDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Seed Roles
			builder.Entity<Role>().HasData(
				new Role { Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
				new Role { Id = 2, Name = "Housekeeper", NormalizedName = "HOUSEKEEPER" },
				new Role { Id = 3, Name = "Client", NormalizedName = "CLIENT" }
				);

			builder.Entity<Category>().HasData(
				new Category { Id = 1, CategoryName = "cleaning and disinfection", CreatedById = 1, CreatedOn = DateTime.Now },
				new Category { Id = 2, CategoryName = "pet and plant care", CreatedById = 1, CreatedOn = DateTime.Now },
				new Category { Id = 3, CategoryName = "child care", CreatedById = 1, CreatedOn = DateTime.Now },
				new Category { Id = 4, CategoryName = "elderly care", CreatedById = 1, CreatedOn = DateTime.Now }
				);

			builder.Entity<Status>().HasData(
				new Status { Id = 1, StatusName = "Waiting", CreatedById = 1, CreatedOn = DateTime.Now },
				new Status { Id = 2, StatusName = "Assigned to domestic helper.", CreatedById = 1, CreatedOn = DateTime.Now },
				new Status { Id = 3, StatusName = "For review", CreatedById = 1, CreatedOn = DateTime.Now },
				new Status { Id = 4, StatusName = "Completed", CreatedById = 1, CreatedOn = DateTime.Now },
				new Status { Id = 5, StatusName = "Denied", CreatedById = 1, CreatedOn = DateTime.Now }
				);


			// Seed Admin user
			string adminPass = "Admin12345!";
			var hasher = new PasswordHasher<User>();
			var admin = new User()
			{
				Id = 1,
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
				EmailConfirmed = true,
				SecurityStamp = string.Empty
			};
			admin.PasswordHash = hasher.HashPassword(admin, adminPass);
			List<User> users = new List<User>()
			{
				admin // и така нататъка
            };
			//builder.Entity<User>().HasData(admin);
			builder.Entity<User>().HasData(users);

			// Seed Admin user with admin role
			builder.Entity<IdentityUserRole<int>>().HasData(
				new IdentityUserRole<int> { UserId = 1, RoleId = 1, }
			);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Exam-e7a2fd91-2869-4c91-83af-453c60ddbe5a;Trusted_Connection=True;MultipleActiveResultSets=true");
			}
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }

		public DbSet<Comment> Comments { get; set; }
		public DbSet<Title> Titles { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
