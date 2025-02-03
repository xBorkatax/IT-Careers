using Exam.Data.Models;
using Exam.Service;
using Exam.Views.Account;
using Exam.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DiaSymReader;

namespace Exam.Controllers
{
    public class BarberController : Controller
    {
        private readonly CommonService commonService;
        private readonly ReviewService reviewService;
        private readonly BarberService barberService;
        public BarberController(CommonService _commonService, BarberService _barberService, ReviewService _reviewService)
        {
            commonService = _commonService;
            reviewService = _reviewService;
            barberService = _barberService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            List<BarberViewModel> barberViewModels;

            if (string.IsNullOrEmpty(searchString))
            {
                barberViewModels = await barberService.GetAll();
            }
            else
            {
                barberViewModels = await barberService.SearchByName(searchString);
            }

            return View(barberViewModels);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new BarberFormModel();
            return View(model);
        }


        private readonly int FileSizeLimit = 2 * 1024 * 1024;
        private readonly string[] PermittedExtensions = { ".jpg", ".png" };
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(BarberFormModel model)
        {
            model.ImageUrl = "1";
            if (model.Name != null && model.Description != null && model.Image != null)
            {

                if (model.Image.Length > FileSizeLimit)
                {
                    ModelState.AddModelError("Image", "File size must be less than 2MB");
                    return View(model);
                }

                var ext = Path.GetExtension(model.Image.FileName).ToLowerInvariant();

                if (string.IsNullOrEmpty(ext) || !PermittedExtensions.Contains(ext))
                {
                    ModelState.AddModelError("Image", "File extension must be either .jpg or .png");
                    return View(model);
                }

                if (model.Image != null)
                {
                    string folder = "Photos/";
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(folder, uniqueFileName);

                    model.ImageUrl = filePath;

                    string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder);


                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    string fullPath = Path.Combine(uploadFolder, uniqueFileName);

                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }
                }
                User user = commonService.FindUser(User);

                model.CreatedById = user.Id;
                await barberService.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int titleId)
        {
            ViewBag.Reviews = await reviewService.GetAllById(titleId);
            BarberViewModel model = await barberService.GetById(titleId);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            BarberEditModel model = await barberService.GetByIdForEdit(id);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(BarberEditModel model)
        {
            if (model.Name != null && model.Description != null)
            {
                if (model.Image != null)
                {
                    if (model.Image.Length > FileSizeLimit)
                    {
                        ModelState.AddModelError("Image", "File size must be less than 2MB");
                        return View(model);
                    }
                    var ext = Path.GetExtension(model.Image.FileName).ToLowerInvariant();

                    if (string.IsNullOrEmpty(ext) || !PermittedExtensions.Contains(ext))
                    {
                        ModelState.AddModelError("Image", "File extension must be either .jpg or .png");
                        return View(model);
                    }
                }
                await barberService.Edit(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            barberService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
