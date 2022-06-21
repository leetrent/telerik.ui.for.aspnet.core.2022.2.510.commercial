using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers.TileLayout
{
    public partial class TileLayoutController : Controller
    {
        [Demo]
        public IActionResult Add_Remove()
        {
            return View();
        }
    }
}
