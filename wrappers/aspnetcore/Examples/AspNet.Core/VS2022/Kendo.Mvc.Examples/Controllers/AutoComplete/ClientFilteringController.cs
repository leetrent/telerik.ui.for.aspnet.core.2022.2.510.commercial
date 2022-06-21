using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class AutoCompleteController : BaseController
    {
        [Demo]
        public IActionResult ClientFiltering()
        {
            return View();
        }

        public JsonResult ClientFiltering_GetProducts()
        {
            using (var northwind = GetContext())
            {
                var products = northwind.Products.Select(product => new ProductViewModel
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice.Value,
                    UnitsInStock = product.UnitsInStock.Value,
                    UnitsOnOrder = product.UnitsOnOrder.Value,
                    Discontinued = product.Discontinued
                });

                return Json(products.ToList());
            }
        }
    }
}