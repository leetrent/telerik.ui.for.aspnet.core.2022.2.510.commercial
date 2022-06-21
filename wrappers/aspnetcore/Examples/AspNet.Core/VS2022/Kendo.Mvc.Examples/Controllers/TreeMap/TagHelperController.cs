using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeMapController : Controller
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            return View();
        }
        public ActionResult TagHelper_PopulationUSA()
        {
            return Json(TreeMapDataRepository.PopulationUSAData());
        }
    }
}