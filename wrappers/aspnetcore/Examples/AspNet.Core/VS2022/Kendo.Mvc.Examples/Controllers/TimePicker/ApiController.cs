using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TimePickerController : Controller
    {
        [Demo]
        public ActionResult Api()
        {
            return View();
        }
    }
}