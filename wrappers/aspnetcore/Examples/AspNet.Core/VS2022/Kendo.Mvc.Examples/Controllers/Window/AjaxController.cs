using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WindowController : Controller
    {
        [Demo]
        public ActionResult Ajax()
        {
            return View();
        }
        public ActionResult AjaxContent()
        {
            return View("AjaxContent");
        }
    }
}