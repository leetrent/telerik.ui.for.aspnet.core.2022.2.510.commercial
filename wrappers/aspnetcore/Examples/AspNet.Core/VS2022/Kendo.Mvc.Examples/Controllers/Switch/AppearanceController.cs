using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SwitchController : Controller
    {
        [Demo]
        public IActionResult Appearance()
        {
            return View();
        }
    }
}