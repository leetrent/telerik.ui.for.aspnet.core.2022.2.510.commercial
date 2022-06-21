using Kendo.Mvc.Examples.Models.Gantt;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            return View();
        }

        public ActionResult TagHelper_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}