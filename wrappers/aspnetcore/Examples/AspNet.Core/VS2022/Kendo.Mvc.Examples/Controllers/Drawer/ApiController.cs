using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DrawerController : Controller
    {
        [Demo]
        public IActionResult Api()
        {
            return View();
        }        
    }
}