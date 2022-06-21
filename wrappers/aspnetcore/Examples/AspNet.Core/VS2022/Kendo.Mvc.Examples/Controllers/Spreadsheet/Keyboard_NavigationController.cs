using Microsoft.AspNetCore.Mvc;
using System;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Keyboard_Navigation_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}