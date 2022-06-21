using Kendo.Mvc.Examples.Models.Gantt;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GanttController : Controller
    {
        [Demo]
        public ActionResult Columns()
        {
            return View();
        }

        public virtual JsonResult Columns_ReadTasks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Columns_DestroyTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Columns_CreateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Columns_UpdateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Columns_ReadDependencies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dependencyService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Columns_DestroyDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Delete(dependency);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Columns_CreateDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Insert(dependency);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }
    }
}