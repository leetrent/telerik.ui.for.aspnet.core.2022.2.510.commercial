using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PanelBarController : Controller
    {
        [Demo]
        public ActionResult Ajax()
        {
            return View();
        }
    }
}