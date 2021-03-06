using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Hierarchy()
        {
            return View();
        }

        public ActionResult HierarchyBinding_Employees([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetEmployees().ToDataSourceResult(request));
        }

        public ActionResult HierarchyBinding_Orders(int employeeID, [DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders()
                .Where(order => order.EmployeeID == employeeID)
                .ToDataSourceResult(request));
        }

		private static IEnumerable<EmployeeViewModel> GetEmployees()
		{
            using (var northwind = new SampleEntitiesDataContext())
            {
                return northwind.Employees.Select(employee => new EmployeeViewModel
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Country = employee.Country,
                    City = employee.City,
                    Notes = employee.Notes,
                    Title = employee.Title,
                    Address = employee.Address,
                    HomePhone = employee.HomePhone
                }).ToList();
            }
		}
	}
}