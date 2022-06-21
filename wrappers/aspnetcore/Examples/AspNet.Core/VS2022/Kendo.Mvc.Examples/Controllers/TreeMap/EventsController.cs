using System;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeMapController : Controller
    {
        [Demo]
        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Events_PopulationUSA()
        {
            return Json(TreeMapDataRepository.PopulationUSAData());
        }
    }
}