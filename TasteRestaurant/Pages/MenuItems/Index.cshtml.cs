using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TasteRestaurant.Data;

namespace TasteRestaurant.Pages.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<MenuItem> MenuItems { get; set; }

        public MenuItem DefaultMenuItem { get; set; }

        public async Task OnGet()
        {
            MenuItems = await _db.MenuItem
                .Include(m => m.CategoryType)
                .Include(m=> m.FoodType)
                .ToListAsync();
        }
    }
}