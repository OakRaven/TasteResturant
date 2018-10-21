﻿using System.Collections.Generic;
using TasteRestaurant.Data;

namespace TasteRestaurant.ViewModels
{
    public class MenuItemViewModel
    {
        public MenuItem MenuItem { get; set; }

        public IEnumerable<CategoryType> CategoryTypes { get; set; }

        public IEnumerable<FoodType> FoodTypes { get; set; }
    }
}