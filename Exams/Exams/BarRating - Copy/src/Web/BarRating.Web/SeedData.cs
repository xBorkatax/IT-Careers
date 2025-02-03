using System;
using System.Threading.Tasks;
using BarRating.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        UserManager<BarRatingUser> userManager = serviceProvider.GetRequiredService<UserManager<BarRatingUser>>();
        RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        IUserStore<BarRatingUser> userStore = serviceProvider.GetRequiredService<IUserStore<BarRatingUser>>();
        IUserEmailStore<BarRatingUser> emailStore = (IUserEmailStore<BarRatingUser>)userStore;

        if ((await userManager.FindByEmailAsync("yav.vasilev@gmail.com")) == null)
        {
            var user = new BarRatingUser()
            {
                UserName = "iavor",
                FirstName = "Iavor",
                LastName = "Vassilev",
                Email = "yav.vasilev@gmail.com"
            };
            await userStore.SetUserNameAsync(user, user.UserName, CancellationToken.None);
            await emailStore.SetEmailAsync(user, user.Email, CancellationToken.None);
            var result = await userManager.CreateAsync(user, "Password1!");
            if ((await roleManager.RoleExistsAsync("Administrator")) == false)
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
            await userManager.AddToRoleAsync(user, "Administrator");
        }
    }
}