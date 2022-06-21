using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DropDownListController : BaseController
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Overview_Get_Categories()
        {
            using (var northwind = GetContext())
            {
                return Json(northwind.Categories
                    .Select(c => new { CategoryId = c.CategoryID, CategoryName = c.CategoryName }).OrderBy(o=>o.CategoryName).ToList());
            }
        }

        public JsonResult Overview_Get_Products(int? categories)
        {
            using (var northwind = GetContext())
            {
                var products = northwind.Products.AsQueryable();

                if (categories != null)
                {
                    products = products.Where(p => p.CategoryID == categories);
                }

                return Json(products.Select(p => new { ProductID = p.ProductID, ProductName = p.ProductName, SupplierCountry = p.Supplier.Country }).ToList());
            }
        }
    }
}