using BarRating.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarRating.Web.Controllers
{
    [Authorize(Roles="Administrator")]
    public class UserController : Controller
    {
        private readonly UserManager<BarRatingUser> userManager;
        private readonly IUserStore<BarRatingUser> userStore;
        private readonly IUserEmailStore<BarRatingUser> emailStore;

        public UserController(UserManager<BarRatingUser> userManager, IUserStore<BarRatingUser> userStore)
        {
            this.userManager = userManager;
            this.userStore = userStore;
            this.emailStore = (IUserEmailStore<BarRatingUser>)userStore;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BarRatingUser barRatingUser, [FromForm] string password)
        {
            if ((await userManager.FindByEmailAsync(barRatingUser.Email)) != null)
            {
                ModelState.AddModelError("Email", $"User with email {barRatingUser.Email} already exists");
            }

            if (ModelState.IsValid)
            {
                await userStore.SetUserNameAsync(barRatingUser, barRatingUser.UserName, CancellationToken.None);
                await emailStore.SetEmailAsync(barRatingUser, barRatingUser.Email, CancellationToken.None);
                var result = await userManager.CreateAsync(barRatingUser, password);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(barRatingUser);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            BarRatingUser userToEdit = await userManager.FindByIdAsync(id);
            return View(userToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BarRatingUser barRatingUser)
        {
            BarRatingUser newBarRatingUser = await userManager.FindByIdAsync(barRatingUser.Id);
            newBarRatingUser.FirstName = barRatingUser.FirstName;
            newBarRatingUser.LastName = barRatingUser.LastName;
            newBarRatingUser.Email = barRatingUser.Email;
            newBarRatingUser.UserName = barRatingUser.UserName;
            await userManager.UpdateAsync(newBarRatingUser);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            BarRatingUser userToDelete = await userManager.FindByIdAsync(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            else
            {
                await userManager.DeleteAsync(userToDelete);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
