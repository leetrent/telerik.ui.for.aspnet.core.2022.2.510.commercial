using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DateInputController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }
    }
}