using Exam.Data.Models;
using Exam.Service;
using Exam.Views.Account;
using Exam.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class TitleController : Controller
    {
        private readonly CommonService commonService;
        private readonly CommentService commentService;
        private readonly TitleService titleService;
        public TitleController(CommonService _commonService, TitleService _titleService, CommentService commentService)
        {
            commonService = _commonService;
            titleService = _titleService;
            this.commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            List<TitleViewModel> titleViewModels;

            if (string.IsNullOrEmpty(searchString))
            {
                titleViewModels = await titleService.GetAll();
            }
            else
            {
                titleViewModels = await titleService.SearchByName(searchString);
            }

            return View(titleViewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new TitleFormModel();
            return View(model);
        }
        

        private readonly int FileSizeLimit = 2 * 1024 * 1024;
        private readonly string[] PermittedExtensions = { ".jpg", ".png" };
        [HttpPost]
        public async Task<IActionResult> Create(TitleFormModel model)
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
                await titleService.Create(model);
                //string returnUrl = HttpContext.Request.Headers["Referer"];
                //return Redirect(returnUrl);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int titleId)
        {
            ViewBag.Comments = await commentService.GetAllById(titleId);
            TitleViewModel model = await titleService.GetById(titleId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            TitleEditModel model = await titleService.GetByIdForEdit(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TitleEditModel model)
        {
            if (ModelState.IsValid)
            {
                await titleService.EditById(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
           titleService.Delete(id);
			return RedirectToAction("Index");
		}
    }
}
