using System;
using System.Collections.Generic;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.TileLayout
{
    public partial class TileLayoutController : Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation()
        {
            return View();
        }
    }
}