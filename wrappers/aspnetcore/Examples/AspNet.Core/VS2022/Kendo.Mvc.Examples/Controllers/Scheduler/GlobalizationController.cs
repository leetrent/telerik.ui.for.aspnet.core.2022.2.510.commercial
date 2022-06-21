using Kendo.Mvc.Examples.Models.Scheduler;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!string.IsNullOrEmpty(context.HttpContext.Request.Query["culture"]))
            {
                CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(context.HttpContext.Request.Query["culture"]);
            }
            base.OnActionExecuting(context);
        }

        [Demo]
        public IActionResult Globalization()
        {
            return View();
        }

        public virtual JsonResult Globalization_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Globalization_Destroy([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Globalization_Create([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Globalization_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
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
