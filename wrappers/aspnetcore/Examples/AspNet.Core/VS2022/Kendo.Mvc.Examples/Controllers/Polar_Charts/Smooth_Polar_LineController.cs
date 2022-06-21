using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Polar_ChartsController : Controller
    {
        [Demo]
        public IActionResult Smooth_Polar_Line()
        {
            return View(ChartDataRepository.SunPosition());
        }
    }
}