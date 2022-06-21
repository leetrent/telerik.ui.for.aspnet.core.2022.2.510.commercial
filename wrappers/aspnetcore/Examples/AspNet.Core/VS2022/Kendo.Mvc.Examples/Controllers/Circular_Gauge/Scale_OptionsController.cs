using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.Circular_Gauge
{
    public partial class Circular_GaugeController : Controller
    {
        [Demo]
        public IActionResult Scale_Options()
        {
            return View();
        }

    }
}
