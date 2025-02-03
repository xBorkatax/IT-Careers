using Exam.Data.Models;
using Exam.Service;
using Exam.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly CommonService commonService;

        public AccountController(UserManager<User> _userManager, SignInManager<User> _signInManager, RoleManager<Role> roleManager, CommonService commonService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            this.roleManager = roleManager;
            this.commonService = commonService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
                await userManager.AddToRoleAsync(user, "Client");
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }


            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var user = await userManager.FindByEmailAsync(model.Email);
            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null /*&& user.IsDeleted = true*/)
            {
                if (user != null && user.IsBanned)
                {
                    return RedirectToAction("Ban");
                }
                else
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        if (model.ReturnUrl != null)
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid login");
            }



            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(int userId)
        {
			var userIdString = userId.ToString(); 
            var user = await userManager.FindByIdAsync(userIdString);
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
			ViewBag.Url = HttpContext.Request.Headers["Referer"].ToString();

			return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            await commonService.EditUser(model, User);
			return Redirect(model.Url);
        }
        public IActionResult Ban()
        {
            return View();
        }
    }
}
