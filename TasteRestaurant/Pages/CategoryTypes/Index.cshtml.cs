using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TasteRestaurant.Data;

namespace TasteRestaurant.Pages.CategoryTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<CategoryType> CategoryTypes { get; set; }
        public CategoryType DefaultCategoryType { get; set; }

        public async Task OnGet()
        {
            CategoryTypes = await _db.CategoryType.OrderBy(i => i.DisplayOrder).ToListAsync();            
        }
    }
}