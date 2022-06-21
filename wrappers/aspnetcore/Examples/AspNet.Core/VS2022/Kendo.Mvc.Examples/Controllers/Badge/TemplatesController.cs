using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class BadgeController : Controller
    {
        [Demo]
        public IActionResult Templates()
        {
            return View();
        }
    }
}