using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class CalendarController : Controller
    {
        [Demo]
        public ActionResult Template()
        {
            return View();
        }
    }
}