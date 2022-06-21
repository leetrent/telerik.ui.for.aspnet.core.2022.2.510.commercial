using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.AppBar
{
    public partial class AppBarController : Controller
    {
        [Demo]
        public IActionResult Index()
        {
            return View();
        }
    }
}
