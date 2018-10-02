using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TasteRestaurant.Data;

namespace TasteRestaurant.Pages.CategoryTypes
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public CategoryType CategoryType { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryType = await _db.CategoryType.SingleOrDefaultAsync(i => i.Id == id);

            if (CategoryType == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            _db.Attach(CategoryType).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}