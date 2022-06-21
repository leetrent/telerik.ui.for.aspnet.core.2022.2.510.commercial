using Kendo.Mvc.Examples.Models.Gantt;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GanttController : Controller
    {
        [Demo]
        public ActionResult Planned_Vs_Actual()
        {
            return View();
        }

        public virtual JsonResult Planned_Vs_Actual_ReadTasks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(Planned_Vs_Actual_GetTasks().ToDataSourceResult(request));
        }

        public virtual JsonResult Planned_Vs_Actual_DestroyTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Planned_Vs_Actual_CreateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Planned_Vs_Actual_UpdateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Planned_Vs_Actual_ReadDependencies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dependencyService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Planned_Vs_Actual_DestroyDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Delete(dependency);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Planned_Vs_Actual_CreateDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Insert(dependency);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public List<TaskViewModel> Planned_Vs_Actual_GetTasks()
        {
            List<TaskViewModel> ganttTasks = new List<TaskViewModel>
            {
                new TaskViewModel
                {
                    TaskID = 7,
                    Title = "Software validation, research and implementation",
                    ParentID = null,
                    OrderId = 0,
                    Start = new DateTime(2020, 6, 1, 3, 0, 0),
                    End = new DateTime(2020, 6, 18, 3, 0, 0),
                    PlannedStart = new DateTime(2020, 6, 1, 3, 0, 0),
                    PlannedEnd = new DateTime(2020, 6, 12, 3, 0, 0),
                    PercentComplete = 0.43M,
                    Summary = true,
                    Expanded = true,
                    TeamLead = "Darrel Solis"
                },
                new TaskViewModel
                {
                    TaskID = 18,
                    Title = "Project Kickoff",
                    ParentID = 7,
                    OrderId = 0,
                    Start = new DateTime(2020, 6, 1, 3, 0, 0),
                    End = new DateTime(2020, 6, 1, 3, 0, 0),
                    PlannedStart = new DateTime(2020, 6, 1, 3, 0, 0),
                    PlannedEnd = new DateTime(2020, 6, 1, 3, 0, 0),
                    PercentComplete = 0.23M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Mallory Gilliam"
                },
                new TaskViewModel
                {
                    TaskID = 13,
                    Title = "Implementation",
                    ParentID = 7,
                    OrderId = 1,
                    Start = new DateTime(2020, 6, 3, 3, 0, 0),
                    End = new DateTime(2020, 6, 17, 3, 0, 0),
                    PlannedStart = new DateTime(2020, 6, 2, 3, 0, 0),
                    PlannedEnd = new DateTime(2020, 6, 17, 3, 0, 0),
                    PercentComplete = 0.77M,
                    Summary = true,
                    Expanded = true,
                    TeamLead = "Mia Caldwell"
                },
                new TaskViewModel
                {
                    TaskID = 24,
                    Title = "Prototype",
                    ParentID = 13,
                    OrderId = 0,
                    Start = new DateTime(2020, 6, 3, 3, 0, 0),
                    End = new DateTime(2020, 6, 5, 3, 0, 0),
                    PlannedStart = new DateTime(2020, 6, 3, 3, 0, 0),
                    PlannedEnd = new DateTime(2020, 6, 6, 3, 0, 0),
                    PercentComplete = 0.77M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Drew Mckay"
                },
                new TaskViewModel
                {
                    TaskID = 26,
                    Title = "Architecture",
                    ParentID = 13,
                    OrderId = 1,
                    Start = new DateTime(2020, 6, 5, 3, 0, 0),
                    End = new DateTime(2020, 6, 7, 3, 0, 0),
                    PlannedStart = new DateTime(2020, 6, 4, 3, 0, 0),
                    PlannedEnd = new DateTime(2020, 6, 6, 3, 0, 0),
                    PercentComplete = 0.82M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Zelda Medina"
                },
                new TaskViewModel
                {
                    TaskID = 27,
                    Title = "Data Layer",
                    ParentID = 13,
                    OrderId = 2,
                    Start = new DateTime(2020, 6, 7, 3, 0, 0),
                    End = new DateTime(2020, 6, 9, 3, 0, 0),
                    PlannedStart = new DateTime(2020, 6, 6, 3, 0, 0),
                    PlannedEnd = new DateTime(2020, 6, 9, 3, 0, 0),
                    PercentComplete = 1.00M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Olga Strong"
                },
                new TaskViewModel
                {
                    TaskID = 28,
                    Title = "Unit Tests",
                    ParentID = 13,
                    OrderId = 4,
                    Start = new DateTime(2020, 6, 14, 3, 0, 0),
                    End = new DateTime(2020, 6, 17, 3, 0, 0),
                    PlannedStart = new DateTime(2020, 6, 10, 3, 0, 0),
                    PlannedEnd = new DateTime(2020, 6, 12, 3, 0, 0),
                    PercentComplete = 0.68M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Christian Palmer"
                },
                new TaskViewModel
                {
                    TaskID = 29,
                    Title = "UI and Interaction",
                    ParentID = 13,
                    OrderId = 5,
                    Start = new DateTime(2020, 6, 7, 3, 0, 0),
                    End = new DateTime(2020, 6, 11, 3, 0, 0),
                    PlannedStart = new DateTime(2020, 6, 6, 3, 0, 0),
                    PlannedEnd = new DateTime(2020, 6, 9, 3, 0, 0),
                    PercentComplete = 0.60M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Moses Duncan"
                },
            };

            return ganttTasks;
        }
    }
}