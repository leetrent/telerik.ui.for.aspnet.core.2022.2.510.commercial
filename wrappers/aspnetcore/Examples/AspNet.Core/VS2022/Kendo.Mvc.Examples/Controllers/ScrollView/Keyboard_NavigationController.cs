using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ScrollViewController : Controller
    {
        [Demo]
        public IActionResult Keyboard_Navigation()
        {
            return View();
        }
    }
}
