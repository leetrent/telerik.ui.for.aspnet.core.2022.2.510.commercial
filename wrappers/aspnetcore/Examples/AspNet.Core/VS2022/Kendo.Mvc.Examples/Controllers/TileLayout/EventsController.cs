using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.TileLayout
{
    public partial class TileLayoutController : Controller
    {
        [Demo]
        public IActionResult Events()
        {
            return View();
        }
    }
}