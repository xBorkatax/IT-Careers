using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        IUserStore<IdentityUser> userStore = serviceProvider.GetRequiredService<IUserStore<IdentityUser>>();
        IUserEmailStore<IdentityUser> emailStore = (IUserEmailStore<IdentityUser>)userStore;

        if ((await userManager.FindByEmailAsync("yav.vasilev@gmail.com")) == null)
        {
            var user = new IdentityUser("yav.vasilev@gmail.com");
            await userStore.SetUserNameAsync(user, "yav.vasilev@gmail.com", CancellationToken.None);
            await emailStore.SetEmailAsync(user, "yav.vasilev@gmail.com", CancellationToken.None);
            var result = await userManager.CreateAsync(user, "Password1!");
            if ((await roleManager.RoleExistsAsync("Administrator")) == false)
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
            await userManager.AddToRoleAsync(user, "Administrator");
        }
    }
}