using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WindowController : Controller
    {
        [Demo]
        public ActionResult BasicUsage()
        {
            return View();
        }
    }
}