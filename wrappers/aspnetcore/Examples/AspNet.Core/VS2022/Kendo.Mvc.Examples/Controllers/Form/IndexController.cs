using System;
using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Examples.Models.Form;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : BaseController
    {
        [Demo]
        public IActionResult Index()
        {
            return View(new UserViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                UserName = "johny",
                Password = "123456",
                DateOfBirth = new DateTime(1990, 5, 8),
                Agree = false
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Index(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData["View"] = "Index";
                return View("Success");
            }
        }

        [Demo]
        public IActionResult Success()
        {
            ViewBag.View = TempData["View"];

            return View();
        }
    }
}