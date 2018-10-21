using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TasteRestaurant.Data;
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
    }
}