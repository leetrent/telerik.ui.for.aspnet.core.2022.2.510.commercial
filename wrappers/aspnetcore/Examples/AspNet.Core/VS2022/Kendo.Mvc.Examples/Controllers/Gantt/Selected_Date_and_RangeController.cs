using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models.Gantt;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GanttController : Controller
    {
        [Demo]
        public ActionResult Selected_Date_and_Range()
        {
            return View();
        }

        public virtual JsonResult Selected_Date_And_Range_ReadTasks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Selected_Date_And_Range_ReadDependencies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dependencyService.GetAll().ToDataSourceResult(request));
        }

    }
}
