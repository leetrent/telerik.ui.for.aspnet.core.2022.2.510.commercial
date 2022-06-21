using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.TreeList;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeListController : Controller
    {
        [Demo]
        public ActionResult Editing_Incell()
        {
            return View();
        }

        private IEmployeeDirectoryService employeeDirectory;

        public TreeListController(
            IEmployeeDirectoryService service)
        {
            employeeDirectory = service;
        }        
        
        public JsonResult All_InCell([DataSourceRequest] DataSourceRequest request)
        {
            var result = GetDirectory().ToTreeDataSourceResult(request,
                e => e.EmployeeId,
                e => e.ReportsTo,
                e => e
            );

            return Json(result);
        }

        public JsonResult Destroy_InCell([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<EmployeeDirectoryModel> employees)
        {
            if (ModelState.IsValid)
            {
                foreach (var employee in employees)
                {
                    employeeDirectory.Delete(employee, ModelState);
                }
            }

            return Json(employees.ToTreeDataSourceResult(request, ModelState));
        }

        public JsonResult Create_InCell([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<EmployeeDirectoryModel> employees)
        {
            if (ModelState.IsValid)
            {
                foreach (var employee in employees)
                {
                    employeeDirectory.Insert(employee, ModelState);
                }
            }

            return Json(employees.ToTreeDataSourceResult(request, ModelState));
        }

        public JsonResult Update_InCell([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<EmployeeDirectoryModel> employees)
        {
            if (ModelState.IsValid)
            {
                foreach (var employee in employees)
                {
                    employeeDirectory.Update(employee, ModelState);
                }
            }

            return Json(employees.ToTreeDataSourceResult(request, ModelState));
        }

        private IEnumerable<EmployeeDirectoryModel> GetDirectory()
        {
            return employeeDirectory.GetAll();
        }        
    }
}