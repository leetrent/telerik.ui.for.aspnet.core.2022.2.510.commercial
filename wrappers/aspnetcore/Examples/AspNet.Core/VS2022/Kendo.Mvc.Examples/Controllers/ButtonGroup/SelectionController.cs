using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ButtonGroupController : Controller
    {
        [Demo]
        public IActionResult Selection()
        {
            return View();
        }
    }
}