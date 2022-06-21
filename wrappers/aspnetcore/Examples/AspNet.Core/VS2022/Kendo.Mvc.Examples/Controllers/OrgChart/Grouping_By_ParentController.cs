using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class OrgChartController : Controller
    {
        [Demo]
        public ActionResult Grouping_By_Parent()
        {
            return View();
        }
        public JsonResult GroupingByParentData([DataSourceRequest] DataSourceRequest request)
        {
            var source = new List<OrgChartEmployeeViewModel>();

            source.Add(new OrgChartEmployeeViewModel() { ID = 1, Name = "Gevin Bell", Title = "CTO", Group = "CEO", Expanded = true, Avatar = "../shared/web/treelist/people/1.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 2, Name = "Clevey Thrustfield", Title = "CEO", Group = "CEO", Expanded = true, Avatar = "../shared/web/treelist/people/2.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 3, Name = "Carol Baker", Title = "CMO", Group = "Chief Officers", Expanded = true, ParentID = 1, Avatar = "../shared/web/treelist/people/3.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 4, Name = "Kendra Howell", Title = "CFO", Group = "Chief Officers", Expanded = false, ParentID = 1, Avatar = "../shared/web/treelist/people/4.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 5, Name = "Sean Rusell", Title = "Financial Manager", Group = "Financial DePartment", Expanded = true, ParentID = 2, Avatar = "../shared/web/treelist/people/5.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 6, Name = "Andrew Berry", Title = "Team Lead", Group = "Team Leads", ParentID = 3, Avatar = "../shared/web/treelist/people/8.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 7, Name = "Jake Miller", Title = "Operations Manager", Group = "Operations Managers", ParentID = 3, Avatar = "../shared/web/treelist/people/9.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 8, Name = "Austin Piper", Title = "Accountant", Group = "Accountants", ParentID = 5, Avatar = "../shared/web/treelist/people/10.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 9, Name = "Dilyana Newman", Title = "Accountant", Group = "Accountants", ParentID = 5, Avatar = "../shared/web/treelist/people/11.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 10, Name = "Eva Andrews", Title = "Operations Manager", Group = "Operations Managers", ParentID = 4, Avatar = "../shared/web/treelist/people/12.jpg" });

            return Json(new
            {
                Data = source
            });
        }
    }
}