using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : BaseController
    {
        [Demo]
        public IActionResult Items()
        {
            return View(new FormItemsViewModels()
            {
                TextBox = "John Doe",
                TextArea = "Multiline\ninput",
                NumericTextBox = 2,
                MaskedTextBox = "21313",
                DatePicker = new DateTime(2020, 5, 7),
                DateTimePicker = new DateTime(2020, 5, 7, 9, 1, 0),
                Switch = false,
                RadioGroup = "1",
                CheckBoxGroup = new string[] { "1", "2" },
                ComboBox = "1",
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Items(FormOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData["View"] = "Items";
                return View("Success");
            }
        }

        public JsonResult Items_GetProducts(string text)
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