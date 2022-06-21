using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WindowController : Controller
    {
        [Demo]
        public ActionResult Api()
        {
            return View();
        }

        public ActionResult LoadAjaxContent()
        {
            return PartialView("LoadAjaxContent");
        }
    }
}