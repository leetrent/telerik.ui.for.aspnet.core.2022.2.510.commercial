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
        public IActionResult Right_To_Left_Support()
        {
            return View();
        }
    }
}
