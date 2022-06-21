using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : BaseController
    {
        [Demo]
        public IActionResult Layout()
        {
            return View(new FormOrderViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                ShipCountry = "France",
                City = "Strasbourg",
                Address = ""
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Layout(FormOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData["View"] = "Layout";
                return View("Success");
            }
        }
    }
}