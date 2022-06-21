using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class RatingController : Controller
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }
    }
}