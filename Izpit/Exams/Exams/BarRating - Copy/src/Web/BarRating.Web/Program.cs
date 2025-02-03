using BarRating.Data;
using BarRating.Data.Models;
using BarRating.Data.Repository;
using BarRating.Data.Repository.Interfaces;
using BarRating.Service.Bar;
using BarRating.Service.Review;
using BarRating.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BarRating.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<BarRatingDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("BarRating.Data")));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<BarRatingUser>(options => options.User.RequireUniqueEmail = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BarRatingDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IReviewFacade, ReviewFacade>();
            builder.Services.AddScoped<IBarFacade, BarFacade>();

            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IBarService, BarService>();

            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IBarRepository, BarRepository>();

            // Add seeding logic
            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                SeedData.Initialize(serviceProvider).Wait();
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
