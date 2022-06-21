using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MenuController : BaseController
    {
        [Demo]
        public ActionResult Animation(string animation, bool? opacity, int? delay)
        {
            ViewBag.animation = animation ?? "toggle";
            ViewBag.opacity = opacity ?? true;
            ViewBag.delay = delay ?? 100;
            return View();
        }
    }
}
