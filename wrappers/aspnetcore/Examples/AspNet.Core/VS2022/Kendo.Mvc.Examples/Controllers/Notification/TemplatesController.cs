using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class NotificationController : Controller
    {
        [Demo]
        public ActionResult Templates()
        {
            return View();
        }
    }
}