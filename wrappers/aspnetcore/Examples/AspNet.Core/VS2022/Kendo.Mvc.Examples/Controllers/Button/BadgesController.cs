using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ButtonController : Controller
    {
        [Demo]
        public IActionResult Badges()
        {
            return View();
        }
    }
}