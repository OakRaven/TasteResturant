using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TasteRestaurant.Data;

namespace TasteRestaurant.Pages.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<FoodType> FoodTypes { get; set; }
        public FoodType DefaultFoodType { get; set; }

        public async Task OnGet()
        {
            FoodTypes = await _db.FoodType.OrderBy(i => i.Name).ToListAsync();            
        }
    }
}