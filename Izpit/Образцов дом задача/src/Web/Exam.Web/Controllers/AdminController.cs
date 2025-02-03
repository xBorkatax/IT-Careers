using Exam.Data.Models;
using Exam.Service;
using Exam.Service.AdminPanel;
using Exam.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
	public class AdminController : Controller
	{
		private readonly AdminService adminService;
		private readonly CommonService commonService;
		public AdminController(AdminService _adminService, CommonService _commonService)
		{
			adminService = _adminService;
			commonService = _commonService;
		}
		public async Task<IActionResult> Index()
		{
			ViewBag.userCount = await adminService.GetUserCount();
            ViewBag.adminCount = await adminService.GetAdminCount();
			List<UserDetailsViewModel> model = await adminService.GetAllUsersAsync();
			return View(model);
		}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateAccount()
        {
            var model = new RegisterViewModel();

            return View(model);
        }
		[HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAccount(RegisterViewModel model)
		{
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await adminService.CreateUser(model);

            return RedirectToAction("Index");
		}
        public async Task<IActionResult> Ban(int userId)
        {
            await adminService.BanUser(userId);
            return RedirectToAction("Index"); 
        }
        public async Task<IActionResult> Unban(int userId)
        {
            await adminService.UnbanUser(userId);
            return RedirectToAction("Index"); 
        }
		public async Task<IActionResult> DeleteUser(int userId)
		{
			if (userId == 1) 
			{
                throw new Exception("Братле, не трий админа");
			} 
			else
			{
				await adminService.DeleteUser(userId);
				return RedirectToAction("Index");
			}
		}
        public async Task<IActionResult> AllTasks()
        {
            List<TaskViewModel> model;
            model = await adminService.GetAllTasks();
            ViewBag.Locations = await commonService.GetAllLocations();
            ViewBag.Categories = await commonService.GetAllCategories();
            ViewBag.Statuses = await commonService.AllStatuses();
            return View(model);
        }
        public IActionResult DeleteTask(int id)
        {
            adminService.DeleteTask(id);
            string returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
        }
    }
}
