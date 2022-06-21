using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Kendo.Mvc.Examples.Models.TaskBoard;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TaskBoardController
    {
        [Demo]
        public IActionResult Templates()
        {
            return View();
        }

        public ActionResult Templates_Columns_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetEmployees().ToDataSourceResult(request));
        }

        private static IList<Column> GetEmployees()
        {
            IList<Column> employees = new List<Column>()
            {
                new Column { ID = 1, Text = "Alex Bennett", Image = "9.jpg" },
                new Column { ID = 2, Text = "Bob McKenna", Image = "6.jpg" },
                new Column { ID = 3, Text = "Charlie Ashworth", Image = "5.jpg" }
            };

            return employees;
        }
    }
}
