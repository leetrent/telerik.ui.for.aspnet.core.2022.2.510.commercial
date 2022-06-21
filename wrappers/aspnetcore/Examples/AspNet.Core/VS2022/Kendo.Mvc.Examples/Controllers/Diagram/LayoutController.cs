using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models.Diagram;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        [Demo]
        public ActionResult Layout()
        {
            return View();
        }

        public ActionResult _DiagramTree()
        {
            return Json(DiagramDataRepository.DiagramNodes());
        }
    }
}