using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class HeatMapController : BaseController
    {
        [Demo]
        public IActionResult Markers()
        {
            return View();
        }
        public IActionResult HeatMap_Markers_Data()
        {
            ICollection<HeatMapModel> data = GetData(10, 20);
            return Json(data);
        }
    }
}
