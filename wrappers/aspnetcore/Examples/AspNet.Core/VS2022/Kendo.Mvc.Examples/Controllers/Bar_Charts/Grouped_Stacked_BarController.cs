using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Bar_ChartsController : Controller
    {
        [Demo]
        public IActionResult Grouped_Stacked_Bar()
        {
            return View();
        }
    }
}