using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.Arc_Gauge
{
    public partial class Arc_GaugeController : Controller
    {
        [Demo]
        public IActionResult Colors()
        {
            return View();
        }
    }
}