using Exam.Data.Models;
using Exam.Service;
using Exam.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Exam.Controllers
{
    public class LocationController : Controller
    {
        private readonly LocationService locationService;
        private readonly CommonService commonService;
        public LocationController(LocationService locationService, CommonService commonService)
        {
            this.locationService = locationService;
            this.commonService = commonService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<LocationViewModel> model = new List<LocationViewModel>();
            model = await locationService.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new LocationFormModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LocationFormModel model)
        {
            if (ModelState.IsValid)
            {
                User user = commonService.FindUser(User);
                model.CreatedById = user.Id;
                await locationService.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            LocationEditModel model = await locationService.GetModelForEdit(id);
            User user = commonService.FindUser(User);
            if (model.CreatedById == user.Id)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LocationEditModel model)
        {
            if (ModelState.IsValid)
            {
                await locationService.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            locationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
