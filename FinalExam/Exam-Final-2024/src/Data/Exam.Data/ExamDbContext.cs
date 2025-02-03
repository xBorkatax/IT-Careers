using Exam.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

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
                new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = 2, Name = "User", NormalizedName = "USER" }
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
        public DbSet<Role> Roles {  get; set; }

        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
