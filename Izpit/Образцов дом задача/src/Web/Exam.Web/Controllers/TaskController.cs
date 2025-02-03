using Exam.Data.Models;
using Exam.Service;
using Exam.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
	public class TaskController : Controller
	{
		private readonly CommonService commonService;
		private readonly LocationService locationService;
        private readonly TaskService taskService;
        public TaskController(CommonService commonService, TaskService taskService, LocationService locationService)
		{
			this.commonService = commonService;
			this.taskService = taskService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			List<TaskViewModel> model;
			User user = commonService.FindUser(User);
			model = await taskService.GetAllByUserId(user.Id);
            ViewBag.Locations = await commonService.GetAllLocationsByUserId(user);
            ViewBag.Categories = await commonService.GetAllCategories();
            ViewBag.Statuses = await commonService.AllStatuses();
            return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			User user = commonService.FindUser(User);
			ViewBag.Locations = await commonService.GetAllLocationsByUserId(user);
			ViewBag.Categories = await commonService.GetAllCategories();
            var model = new TaskFormModel();
			model.CreatedById = user.Id;
			model.StatusId = 1;
            return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Create(TaskFormModel model)
		{
			if (ModelState.IsValid)
			{
				await taskService.Create(model);
				return RedirectToAction("Index");
			}
			return View(model);
		}

        public IActionResult Cancel(int id)
        {
			taskService.CancelTask(id);
			return RedirectToAction("Index");
		}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            TaskEditModel model = await taskService.GetModelForEdit(id);
            User user = commonService.FindUser(User);
			if (model.CreatedById == user.Id || user.Id == 1) 
			{ 
				ViewBag.Locations = await commonService.GetAllLocationsByUserId(user);
				ViewBag.Categories = await commonService.GetAllCategories();
				return View(model);
			}
			else
			{
				return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TaskEditModel model)
        {
			if (ModelState.IsValid)
			{
				await taskService.Edit(model);
				return RedirectToAction("Index");
			}
            return View(model);
        }
    }
}
