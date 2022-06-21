using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MultiViewCalendarController : Controller
    {
        //
        // GET: /Week_Column/
        [Demo]
        public ActionResult Week_Column()
        {
            return View();
        }

    }
}
