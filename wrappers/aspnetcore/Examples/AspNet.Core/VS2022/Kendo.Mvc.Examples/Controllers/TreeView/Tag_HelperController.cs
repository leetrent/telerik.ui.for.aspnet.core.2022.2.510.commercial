using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeViewController : BaseController
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            using (var northwind = new SampleEntitiesDataContext())
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