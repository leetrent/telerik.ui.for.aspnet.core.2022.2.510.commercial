using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Bar_ChartsController : Controller
    {
        [Demo]
        public IActionResult Grouped_Stacked100_Bar()
        {
            return View();
        }
    }
}