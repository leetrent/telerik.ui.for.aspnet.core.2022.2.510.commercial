using Kendo.Mvc.Examples.Models.Gantt;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GanttController : Controller
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            return View();
        }

        public virtual JsonResult TagHelper_ReadTasks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult TagHelper_DestroyTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult TagHelper_CreateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult TagHelper_UpdateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult TagHelper_ReadDependencies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dependencyService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult TagHelper_DestroyDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Delete(dependency);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult TagHelper_CreateDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Insert(dependency);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult TagHelper_ReadResources([DataSourceRequest] DataSourceRequest request)
        {
            return Json(resourceService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult TagHelper_ReadAssignments([DataSourceRequest] DataSourceRequest request)
        {
            return Json(assignmentService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult TagHelper_DestroyAssignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Delete(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult TagHelper_CreateAssignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Insert(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult TagHelper_UpdateAssignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Update(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }
    }
}