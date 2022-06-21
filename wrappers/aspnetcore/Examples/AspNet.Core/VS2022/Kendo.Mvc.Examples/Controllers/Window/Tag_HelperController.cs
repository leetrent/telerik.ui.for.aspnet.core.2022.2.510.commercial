using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WindowController : Controller
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            return View();
        }

        public ActionResult AjaxContent_TagHelper()
        {
            return View("AjaxContent");
        }
    }
}