using Kendo.Mvc.Examples.Models.Scheduler;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController
    {
        [Demo]
        public IActionResult Basic_Usage()
        {
            return View();
        }

        public virtual JsonResult Basic_Usage_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Basic_Usage_Destroy([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Basic_Usage_Create([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Basic_Usage_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            //example custom validation:
            if (task.Start.Hour < 8 || task.Start.Hour > 22)
            {
                ModelState.AddModelError("start", "Start date must be in working hours (8h - 22h)");
            }

            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }
    }
}