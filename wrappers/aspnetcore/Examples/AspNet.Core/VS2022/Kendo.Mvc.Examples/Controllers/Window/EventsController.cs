using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WindowController : Controller
    {
        [Demo]
        public ActionResult Events()
        {
            return View();
        }
        public ActionResult LoadContent()
        {
            return PartialView("LoadAjaxContent");
        }
    }
}