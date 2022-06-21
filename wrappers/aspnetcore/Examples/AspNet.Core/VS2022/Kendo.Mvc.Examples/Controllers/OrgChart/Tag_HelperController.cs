using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class OrgChartController : Controller
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            return View();
        }
    }
}