using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PagerController : Controller
    {
        [Demo]
        public IActionResult Integration()
        {
            return View();
        }
    }
}