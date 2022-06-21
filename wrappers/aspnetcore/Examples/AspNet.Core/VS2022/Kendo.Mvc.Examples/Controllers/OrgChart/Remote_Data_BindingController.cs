using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.TreeList;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class OrgChartController : Controller
    {
        private IEmployeeDirectoryService employeeDirectory;

        public OrgChartController(IEmployeeDirectoryService service)
        {
            employeeDirectory = service;
        }

        [Demo]
        public ActionResult Remote_Data_Binding()
        {
            return View();
        }

        public JsonResult RemoteDataBindingData([DataSourceRequest] DataSourceRequest request)
        {
            var source = ((EmployeeDirectoryService)employeeDirectory).GetAllRemote().Take(5)
                .Select((x, i) => new OrgChartEmployeeViewModel()
                {
                    ID = x.EmployeeId,
                    Name = x.FirstName + " " + x.LastName,
                    ParentID = x.ReportsTo,
                    Title = x.Position,
                    Avatar = "../shared/web/treelist/people/" + (i + 1) + ".jpg",
                }).ToList<OrgChartEmployeeViewModel>();

            source[0].Expanded = true;

            return Json(new
            {
                Data = source
            });
        }
    }
}