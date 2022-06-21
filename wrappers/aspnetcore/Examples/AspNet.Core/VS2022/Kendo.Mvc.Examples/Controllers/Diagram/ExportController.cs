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
        public ActionResult Export()
        {
            ViewData["baseUrl"] = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            return View();
        }

        public ActionResult Export_Read()
        {
            return Json(DiagramDataRepository.OrgChart());
        }

        [HttpPost]
        public ActionResult Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}