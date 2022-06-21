using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Line_ChartsController : Controller
    {
        [Demo]
        public IActionResult Visuals()
        {
            return View(ChartDataRepository.ForecastData());
        }
    }
}