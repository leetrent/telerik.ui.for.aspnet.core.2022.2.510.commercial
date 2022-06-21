using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Chart_ApiController : Controller
    {
        [Demo]
        public ActionResult Events()
        {
            return View();
        }

        [HttpPost]
        public IActionResult _SpainElectricityProduction()
        {
            return Json(ChartDataRepository.SpainElectricityProduction());
        }
    }
}