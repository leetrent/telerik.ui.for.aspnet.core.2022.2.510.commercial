using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TabStripController : Controller
    {
        [Demo]
        public ActionResult Animation(string animation, bool? opacity)
        {
            ViewBag.animation = animation ?? "expand";
            ViewBag.opacity = opacity ?? true;

            return View();
        }
    }
}