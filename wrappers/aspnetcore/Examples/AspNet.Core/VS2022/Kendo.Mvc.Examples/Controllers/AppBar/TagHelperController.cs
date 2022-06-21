using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.AppBar
{
    public partial class AppBarController : Controller
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }
    }
}
