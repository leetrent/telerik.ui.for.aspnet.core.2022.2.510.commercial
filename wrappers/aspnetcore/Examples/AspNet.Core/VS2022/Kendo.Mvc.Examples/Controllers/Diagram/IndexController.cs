using Kendo.Mvc.Examples.Models.Diagram;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        [Demo]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _OrgChart()
        {
            return Json(DiagramDataRepository.OrgChart());
        }
    }
}