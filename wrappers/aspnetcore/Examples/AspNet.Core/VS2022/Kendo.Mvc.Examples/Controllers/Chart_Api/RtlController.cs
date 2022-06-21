using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Chart_ApiController : Controller
    {
        [Demo]
        public ActionResult Rtl()
        {
            return View();
        }
    }
}