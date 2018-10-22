﻿using System;
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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EditModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public MenuItemViewModel MenuItemVM { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MenuItemVM = new MenuItemViewModel
            {
                MenuItem = _db.MenuItem
                    .Include(i => i.CategoryType)
                    .Include(i => i.FoodType)
                    .SingleOrDefault(i => i.Id == id),
                CategoryTypes = _db.CategoryType.ToList(),
                FoodTypes = _db.FoodType.ToList()
            };

            if (MenuItemVM.MenuItem == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}