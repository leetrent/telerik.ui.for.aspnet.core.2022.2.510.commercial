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
        public IActionResult Pan_And_Zoom()
        {
            return View();
        }

        public IActionResult HeatMap_Data()
        {
            ICollection<HeatMapModel> data = GetData(25, 25);
            return Json(data);
        }
    }
}
