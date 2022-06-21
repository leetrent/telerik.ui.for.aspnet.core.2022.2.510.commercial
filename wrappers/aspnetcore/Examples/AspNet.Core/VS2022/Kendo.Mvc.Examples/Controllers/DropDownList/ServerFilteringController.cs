using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DropDownListController : BaseController
    {
        [Demo]
        public ActionResult ServerFiltering()
        {
            return View();
        }

        public JsonResult ServerFiltering_GetProducts(string text)
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

                if (!string.IsNullOrEmpty(text))
                {
                    products = products.Where(p => p.ProductName.Contains(text));
                }

                return Json(products.ToList());
            }
        }
    }
}