using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MapController : BaseController
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            return View();
        }
    }
}