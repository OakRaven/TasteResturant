using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasteRestaurant.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        {
            return items.Select(i => new SelectListItem {
                Text = i.GetPropertyValue("Name"),
                Value = i.GetPropertyValue("Id"),
                Selected = i.GetPropertyValue("Id").Equals(selectedValue.ToString())
            });
        }
    }
}
