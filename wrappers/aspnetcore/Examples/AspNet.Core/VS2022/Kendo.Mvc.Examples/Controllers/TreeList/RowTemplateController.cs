using Kendo.Mvc.Examples.Models.TreeList;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeListController : Controller
    {
        [Demo]
        public ActionResult RowTemplate()
        {
            return View();
        }

        private string GetAbbreviation(int employeeId)
        {
            if (employeeId % 5 == 0)
            {
                return "bg";
            }

            else if (employeeId % 5 == 1)
            {
                return "us";
            }

            else if (employeeId % 5 == 2)
            {
                return "gb";
            }

            else if (employeeId % 5 == 3)
            {
                return "fr";
            }

            else
            {
                return "it";
            }
        }

        public JsonResult AllWithCountryAndColor([DataSourceRequest] DataSourceRequest request)
        {
            var result = GetDirectory().Select(x => new EmployeeDirectoryModel()
            {
                Address = x.Address,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmployeeId = x.EmployeeId,
                HireDate = x.HireDate,
                Position = x.Position,
                ReportsTo = x.ReportsTo,
                CountryFlag = GetAbbreviation(x.EmployeeId)
            }).ToTreeDataSourceResult(request,
                e => e.EmployeeId,
                e => e.ReportsTo,
                e => e
            );

            return Json(result);
        }
    }
}