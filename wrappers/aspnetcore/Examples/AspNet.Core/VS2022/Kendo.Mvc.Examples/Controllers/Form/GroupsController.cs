using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : BaseController
    {
        [Demo]
        public IActionResult Groups()
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
        public ActionResult Groups(FormOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData["View"] = "Groups";
                return View("Success");
            }
        }
    }
}