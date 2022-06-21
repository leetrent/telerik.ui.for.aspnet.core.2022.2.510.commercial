using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.ColorPalette
{
    public partial class ColorPaletteController : Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation()
        {
            return View();
        }
    }
}
