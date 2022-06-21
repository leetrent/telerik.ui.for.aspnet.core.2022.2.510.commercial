using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ScrollViewController : Controller
    {
        [Demo]
        public IActionResult Index()
        {
            return View();
        }
    }
}
