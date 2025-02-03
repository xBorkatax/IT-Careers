using BarRating.Data.Models;
using BarRating.Service.Bar;
using BarRating.Service.Models;
using BarRating.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BarRating.Web.Controllers
{
    public class BarController : Controller
    {
        private readonly IBarFacade barFacade;
        private readonly IBarService barService;

        private readonly int FileSizeLimit = 2 * 1024 * 1024;
        private readonly string[] PermittedExtensions = { ".jpg", ".png" };

        public BarController(IBarFacade barFacade, IBarService barService)
        {
            this.barFacade = barFacade;
            this.barService = barService;
        }

        public IActionResult Index()
        {
            return View(barFacade.GetBarViewModels());
        }

        public IActionResult GetImage(string id)
        {
            BarDto restaurant = barService.GetBarById(id);

            return File(restaurant.Image, "image/png");
        }

        [HttpGet]
		[Authorize(Roles = "Administrator")]
		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Create(BarCreationModel bar)
        {
            if (bar.Image.Length > FileSizeLimit)
            {
                ModelState.AddModelError("Image", "File size must be less than 2MB");
            }

            var ext = Path.GetExtension(bar.Image.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !PermittedExtensions.Contains(ext))
            {
                ModelState.AddModelError("Image", "File extension must be either .img or .png");
            }

            if (ModelState.IsValid)
            {
                await barFacade.CreateBar(bar);
                return RedirectToAction(nameof(Index));
            }

            return View(bar);
        }

		[Authorize(Roles = "Administrator")]
		public IActionResult Edit(string id)
        {
            return View(barFacade.GetBarUpdateModelById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(BarUpdateModel barUpdateModel)
        {
            if (ModelState.IsValid)
            {
                await barFacade.UpdateBar(barUpdateModel);
                return RedirectToAction(nameof(Index));
            }

            return View(barUpdateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public IActionResult Delete(string id)
        {
            if (barService.DeleteById(id) == 1)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
