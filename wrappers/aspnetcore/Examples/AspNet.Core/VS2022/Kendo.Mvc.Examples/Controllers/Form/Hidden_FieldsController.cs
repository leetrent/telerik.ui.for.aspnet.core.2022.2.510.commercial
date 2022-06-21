using Kendo.Mvc.Examples.Models.Form;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : BaseController
    {
        [Demo]
        public IActionResult Hidden_Fields()
        {
            return View(new UserViewModel()
            {
                UserID = 1,
                UserName = "johny",
                Password = "123456",
                Email = "john.doe@email.com"
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Hidden_Fields(UserViewModel model)
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
    }
}
