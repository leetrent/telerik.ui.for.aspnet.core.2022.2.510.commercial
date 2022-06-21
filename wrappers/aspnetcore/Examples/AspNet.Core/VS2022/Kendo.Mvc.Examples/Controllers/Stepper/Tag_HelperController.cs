using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class StepperController : Controller
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            return View();
        }
    }
}