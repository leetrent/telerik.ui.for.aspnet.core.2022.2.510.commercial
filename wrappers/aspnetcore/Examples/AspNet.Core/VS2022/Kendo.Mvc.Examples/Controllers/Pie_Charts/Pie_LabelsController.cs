using Microsoft.AspNetCore.Mvc;
namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Pie_ChartsController : Controller
    {
        [Demo]
        public IActionResult Pie_Labels()
        {
            return View();
        }
    }
}