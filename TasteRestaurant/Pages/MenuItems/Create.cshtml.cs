using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TasteRestaurant.Data;
using TasteRestaurant.Utils;
using TasteRestaurant.ViewModels;

namespace TasteRestaurant.Pages.MenuItems
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CreateModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public MenuItemViewModel MenuItemVM{ get; set; }

        public IActionResult OnGet()
        {
            MenuItemVM = new MenuItemViewModel
            {
                MenuItem = new MenuItem(),
                CategoryTypes = _db.CategoryType.ToList(),
                FoodTypes = _db.FoodType.ToList()
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }

            _db.MenuItem.Add(MenuItemVM.MenuItem);
            await _db.SaveChangesAsync();

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var menuItemFromDb = _db.MenuItem.Find(MenuItemVM.MenuItem.Id);

            if(files.Count > 0 && files[0]?.Length > 0)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, string.Format("{0}{1}", MenuItemVM.MenuItem.Id, extension)), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                    menuItemFromDb.Image = string.Format("/images/{0}{1}", MenuItemVM.MenuItem.Id, extension);
                }
            } else
            {
                var uploads = Path.Combine(webRootPath, @"images\" + StaticDetails.DefaultFoodImage);
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + MenuItemVM.MenuItem.Id + ".jpg");
                menuItemFromDb.Image = "/images/" + StaticDetails.DefaultFoodImage;
            }
            
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}