using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuideToFlavors.Data;
using GuideToFlavors.Models.Restaurant;
using GuideToFlavors.Services.Restaurant;
using GuideToFlavors.ServiceModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static System.Net.Mime.MediaTypeNames;
using System.IO.Compression;
using GuideToFlavors.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using GuideToFlavors.ServiceMappings;
using System.Collections;
using System.Drawing;
using Image = System.Drawing.Image;

namespace GuideToFlavors.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly UserManager<GuideToFlavorsUser> userManager;
        private readonly IRestaurantService restaurantService;

        private readonly int fileSizeLimit = 2 * 1024 * 1024;
        private readonly string[] permittedExtensions = { ".jpg", ".png" };

        public RestaurantsController(UserManager<GuideToFlavorsUser> userManager, IRestaurantService restaurantService)
        {
            this.userManager = userManager;
            this.restaurantService = restaurantService;
        }

        // GET: Restaurants
        public IActionResult Index()
        {
            IEnumerable<RestaurantDto> restaurants = restaurantService.GetAll();

            return View(restaurants);
        }

        public IActionResult GetImage(string id)
        {
            RestaurantDto restaurant = restaurantService.GetAll().SingleOrDefault(r => r.Id == id);

            return File(restaurant.Image, "image/png");
        }

        /*// GET: Restaurants/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.CreatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }*/

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(RestaurantCreationModel restaurant)
        {
            if (restaurant.Image.Length > fileSizeLimit)
            {
                ModelState.AddModelError("Image", "File size must be less than 2MB");
            }

            var ext = Path.GetExtension(restaurant.Image.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                ModelState.AddModelError("Image", "File extension must be either .img or .png");
            }

            if (ModelState.IsValid)
            {
                byte[] fileContents;
                using (var memoryStream = new MemoryStream())
                {
                    await restaurant.Image.CopyToAsync(memoryStream);
                    fileContents = memoryStream.ToArray();
                }

                RestaurantDto restaurantDto = new RestaurantDto()
                {
                    Name = restaurant.Name,
                    Description = restaurant.Description,
                    Image = fileContents
                };

                await restaurantService.Create(restaurantDto, (await userManager.GetUserAsync(User)));
                return RedirectToAction(nameof(Index));
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        /*public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Id", restaurant.CreatedById);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Image,CreatedById,CreatedOn,Id")] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Id", restaurant.CreatedById);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.CreatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(string id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }*/
    }
}
