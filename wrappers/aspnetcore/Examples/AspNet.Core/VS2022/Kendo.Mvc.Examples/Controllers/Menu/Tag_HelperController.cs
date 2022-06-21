using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MenuController : BaseController
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            using (var northwind = GetContext())
            {
                var categories = northwind.Categories.ToList();
                categories.ForEach(c =>
                                   c.Products = northwind.Products
                                    .Where(p => p.CategoryID == c.CategoryID)
                                    .ToList());

                return View(categories);
            }
        }
    }
}