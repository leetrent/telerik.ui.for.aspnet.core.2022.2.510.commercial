using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class CheckBoxGroupController : Controller
    {
        [Demo]
        public IActionResult Events()
        {

            return View();
        }
    }
}