using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MultiViewCalendarController : Controller
    {
        //
        // GET: /Selection/
        [Demo]
        public ActionResult Selection()
        {
            return View();
        }

    }
}
