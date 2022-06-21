using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.TileLayout
{
    [Demo]
    public partial class TileLayoutController : Controller
    {
        public IActionResult Resizing()
        {
            return View();
        }
    }
}