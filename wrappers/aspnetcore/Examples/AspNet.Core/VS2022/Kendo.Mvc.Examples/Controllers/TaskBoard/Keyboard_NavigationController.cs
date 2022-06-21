using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TaskBoardController
    {
        [Demo]
        public IActionResult Keyboard_Navigation()
        {
            ViewBag.Cards = GetCards();

            return View();
        }
    }
}
