using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Funnel_ChartsController : Controller
    {
        [Demo]
        public IActionResult Index()
        {
            return View();
        }
    }
}