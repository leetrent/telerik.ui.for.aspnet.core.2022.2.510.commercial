using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class BadgeController : Controller
    {
        [Demo]
        public IActionResult Labels()
        {
            return View();
        }

        public ActionResult GetIssues([DataSourceRequest] DataSourceRequest request)
        {
            return Json(new List<IssueModel>
            {
                new IssueModel  {
                    Id = 1,
                    Title = "Implement lazy loading",
                    AdditionalInfo = "opened 13 days ago by starku",
                    Type = "feature",
                    Approved = false
                },
                new IssueModel {
                    Id = 2,
                    Title = "Scrolling freezes in IE 8",
                    AdditionalInfo = "opened 2 days ago by gink",
                    Type = "bug",
                    Approved = true
                },
                new IssueModel {
                    Id = 3,
                    Title = "Keyboard navigation throws an exception",
                    AdditionalInfo = "opened 1 days ago by toydivas",
                    Type = "bug",
                    Approved = true
                },
                new IssueModel {
                    Id = 4,
                    Title = "Improve searching performance",
                    AdditionalInfo = "opened 12 days ago by peterC",
                    Type = "enhancement",
                    Approved = false
                },
                new IssueModel {
                    Id = 5,
                    Title = "Add documentation for lazy loading",
                    AdditionalInfo = "opened 11 days ago by starku",
                    Type = "documentation",
                    Approved = true
                }
            }.ToDataSourceResult(request));
        }
    }
}