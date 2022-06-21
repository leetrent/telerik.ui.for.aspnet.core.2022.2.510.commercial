using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeMapController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BasicUsage_PopulationUSA()
        {
            return Json(TreeMapDataRepository.PopulationUSAData());
        }
    }
}