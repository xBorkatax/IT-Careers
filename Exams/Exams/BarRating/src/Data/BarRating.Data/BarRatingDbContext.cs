using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BarRating.Data.Models;

namespace BarRating.Web.Data
{
    public class BarRatingDbContext : IdentityDbContext<BarRatingUser>
    {
        public BarRatingDbContext(DbContextOptions<BarRatingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        DbSet<Bar> Bars { get; set; }
        DbSet<Review> Reviews { get; set; }
    }
}
