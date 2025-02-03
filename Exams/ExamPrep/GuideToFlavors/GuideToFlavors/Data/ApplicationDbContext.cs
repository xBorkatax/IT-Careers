using GuideToFlavors.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuideToFlavors.Data
{
	public class ApplicationDbContext : IdentityDbContext<GuideToFlavorsUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<Review> Reviews { get; set; }
	}
}
