using System;
using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Examples.Models.Form;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FloatingActionButtonController : Controller
    {
        [Demo]
        public IActionResult Api()
        {
            return View();
        }
    }
}