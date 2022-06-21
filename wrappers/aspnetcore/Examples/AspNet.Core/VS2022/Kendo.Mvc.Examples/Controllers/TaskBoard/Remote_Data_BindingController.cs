using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Scheduler;
using Kendo.Mvc.Examples.Models.TaskBoard;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TaskBoardController
    {
        [Demo]
        public ActionResult Remote_Data_Binding()
        {
            return View();
        }

        public virtual JsonResult Remote_Data_Binding_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Remote_Data_Binding_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Remote_Data_Binding_Columns_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetColumns().ToDataSourceResult(request));
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
