using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MultiViewCalendarController : Controller
    {
        [Demo]
        public ActionResult Multiple_Views()
        {
            return View();
        }
    }
}