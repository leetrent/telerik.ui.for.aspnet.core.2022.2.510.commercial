using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class BottomNavigationController : BaseController
    {
        [Demo]
        public IActionResult Appearance()
        {
            return View();
        }
    }
}
