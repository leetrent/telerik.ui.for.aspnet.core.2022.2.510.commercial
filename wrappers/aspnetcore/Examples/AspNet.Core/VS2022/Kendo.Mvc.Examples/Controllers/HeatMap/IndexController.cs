using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class HeatMapController : BaseController
    {
        [Demo]
        public IActionResult Index()
        {
            return View();
        }
    }
}
