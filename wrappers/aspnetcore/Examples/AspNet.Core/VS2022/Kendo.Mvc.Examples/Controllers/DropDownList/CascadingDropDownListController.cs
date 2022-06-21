using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DropDownListController : BaseController
    {
        [Demo]
        public ActionResult CascadingDropDownList()
        {
            return View();
        }

        public JsonResult Cascading_GetCategories()
        {
            using (var northwind = GetContext())
            {
                return Json(northwind.Categories
                    .Select(c => new { CategoryId = c.CategoryID, CategoryName = c.CategoryName }).ToList());
            }
        }

        public JsonResult Cascading_GetProducts(int? categories)
        {
            using (var northwind = GetContext())
            {
                var products = northwind.Products.AsQueryable();

                if (categories != null)
                {
                    products = products.Where(p => p.CategoryID == categories);
                }

                return Json(products.Select(p => new { ProductID = p.ProductID, ProductName = p.ProductName }).ToList());
            }
        }

        public JsonResult Cascading_GetOrders(int? products)
        {
            using (var northwind = new SampleEntitiesDataContext())
            {
                var orders = northwind.OrderDetails.AsQueryable();

                if (products != null)
                {
                    orders = orders.Where(o => o.ProductID == products);
                }

                return Json(orders.Select(o => new { OrderID = o.OrderID, ShipCity = o.Order.ShipCity }).ToList());
            }
        }
    }
}