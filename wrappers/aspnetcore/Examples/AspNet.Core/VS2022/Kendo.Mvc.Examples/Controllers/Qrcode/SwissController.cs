using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class QrcodeController : Controller
    {
        [Demo]
        public IActionResult Swiss()
        {
            return View();
        }
    }
}
