using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models.Scheduler;
using Kendo.Mvc.Examples.Models.TaskBoard;

namespace Kendo.Mvc.Examples.Controllers.TaskBoard
{
    public partial class TaskBoardController : Controller
    {
        private ISchedulerEventService<TaskViewModel> taskService;

        public const string SessionKeyID = "ID";
        private List<Column> columns = GetColumns() as List<Column>;

        public TaskBoardController(
            ISchedulerEventService<TaskViewModel> schedulerTaskService)
        {
            taskService = schedulerTaskService;
        }

        [Demo]
        public ActionResult Editing()
        {
            return View();
        }

        public virtual JsonResult Tasks_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Tasks_Destroy([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Tasks_Create([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Tasks_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Editing_Columns_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetColumns().ToDataSourceResult(request));
        }

        public virtual JsonResult Editing_Columns_Destroy([DataSourceRequest] DataSourceRequest request, Column column)
        {
            if (ModelState.IsValid)
            {
                columns.Remove(columns.Where(x => x.ID == column.ID).FirstOrDefault());
            }

            return Json(new[] { column }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Editing_Columns_Create([DataSourceRequest] DataSourceRequest request, Column column)
        {
            if (ModelState.IsValid)
            {
                if (column.ID == 0)
                {
                    column.ID = GetColumns().Last().ID + 1;
                    HttpContext.Session.SetInt32(SessionKeyID, column.ID);
                }
            }

            return Json(new[] { column }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Editing_Columns_Update([DataSourceRequest] DataSourceRequest request, Column column)
        {
            if (ModelState.IsValid)
            {
                var taskToUpdate = columns.Where(x => x.ID == column.ID).FirstOrDefault();
                if (taskToUpdate != null)
                {
                    taskToUpdate = column;
                }
            }

            return Json(new[] { column }.ToDataSourceResult(request, ModelState));
        }

        private static IList<Column> GetColumns()
        {
            IList<Column> taskBoardColumns = new List<Column>()
            {
                new Column { ID = 1, Text = "Pending", Status = "pending" },
                new Column { ID = 2, Text = "Under Review", Status = "underReview" },
                new Column { ID = 3, Text = "Scheduled", Status = "scheduled" }
            };

            return taskBoardColumns;
        }
    }
}
