using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TextAreaController : Controller
    {
        [Demo]
        public IActionResult Appearance()
        {
            return View();
        }
    }
}