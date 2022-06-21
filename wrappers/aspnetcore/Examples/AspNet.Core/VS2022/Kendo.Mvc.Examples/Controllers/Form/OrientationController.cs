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
        public IActionResult Orientation()
        {
            return View(new UserViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                UserName = "johny",
                Password = "123456",
                DateOfBirth = new DateTime(2020, 5, 8),
                Agree = false
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Orientation(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData["View"] = "Orientation";
                return View("Success");
            }
        }
    }
}