using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        [Demo]
        public ActionResult Events()
        {
            return View();
        }
    }
}