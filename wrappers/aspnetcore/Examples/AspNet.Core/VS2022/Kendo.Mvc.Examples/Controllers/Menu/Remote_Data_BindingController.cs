using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MenuController : BaseController
    {
        [Demo]
        public ActionResult Remote_Data_Binding()
        {
            return View();
        }


        public JsonResult GetCategories()
        {
            var northwind = GetContext();

            var result = northwind.Categories.ToList().Select((category) => 
                new
                {
                    Name = category.CategoryName,
                    Products = northwind.Products
                        .Where((product) => product.CategoryID == category.CategoryID)
                        .Select((product)=> new { Name = product.ProductName })
                }
            );

            return Json(result);
        }
    }
}
