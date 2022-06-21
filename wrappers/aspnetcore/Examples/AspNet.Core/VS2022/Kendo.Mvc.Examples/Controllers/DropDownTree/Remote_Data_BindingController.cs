using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers.DropDownTree
{
    public partial class DropDownTreeController : BaseController
    {
        [Demo]
        public ActionResult Remote_Data_Binding()
        {
            return View();
        }

        public JsonResult Remote_Data_Binding_Get_Employees(int? id)
        {
            using (var dataContext = new SampleEntitiesDataContext())
            {
                var employees = from e in dataContext.Employees
                                where (id.HasValue ? e.ReportsTo == id : e.ReportsTo == null)
                                select new
                                {
                                    id = e.EmployeeID,
                                    Name = e.FirstName + " " + e.LastName,
                                    hasChildren = (from q in dataContext.Employees
                                                   where (q.ReportsTo == e.EmployeeID)
                                                   select q
                                                   ).Count() > 0
                                };

                return Json(employees.ToList());
            }
        }
    }
}
