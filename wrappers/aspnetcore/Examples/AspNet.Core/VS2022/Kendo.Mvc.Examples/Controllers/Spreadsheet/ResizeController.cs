using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers.Spreadsheet
{
    public partial class SpreadsheetController : Controller
    {
        [Demo]
        public ActionResult Resize()
        {
            return View();
        }
    }
}
