using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Examples.Models.Form;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WizardController : Controller
    {
        [Demo]
        public IActionResult Keyboard_Navigation()
        {
            return View(new UserViewModel());
        }
    }
}