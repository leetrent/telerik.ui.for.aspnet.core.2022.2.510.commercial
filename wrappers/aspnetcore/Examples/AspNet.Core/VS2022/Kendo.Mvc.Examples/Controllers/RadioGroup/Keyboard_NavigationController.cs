using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.RadioGroup
{
    public partial class RadioGroupController : Controller
    {
        [Demo]
        public IActionResult Keyboard_Navigation()
        {
            return View();
        }
    }
}
