using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WindowController : Controller
    {
        [Demo]
        public ActionResult Index(string animation, bool? opacity, bool? draggable, bool? resizable)
        {
            ViewBag.animation = animation ?? "expand";
            ViewBag.opacity = opacity ?? true;
            ViewBag.draggable = draggable ?? true;
            ViewBag.resizable = resizable ?? true;

            return View();
        }
    }
}