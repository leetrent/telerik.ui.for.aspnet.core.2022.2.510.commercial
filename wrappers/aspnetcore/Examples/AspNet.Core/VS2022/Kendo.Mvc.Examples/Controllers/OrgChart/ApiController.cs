using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class OrgChartController : Controller
    {
        [Demo]
        public ActionResult Api()
        {
            return View();
        }
        public JsonResult ApiData([DataSourceRequest] DataSourceRequest request)
        {
            var source = new List<OrgChartEmployeeViewModel>();

            source.Add(new OrgChartEmployeeViewModel() { ID = 1, Name = "Gevin Bell", Title = "CEO", Expanded = true, Avatar = "../shared/web/treelist/people/1.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 2, Name = "Clevey Thrustfield", Title = "COO", Expanded = true, ParentID = 1, Avatar = "../shared/web/treelist/people/2.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 3, Name = "Carol Baker", Title = "CFO", Expanded = false, ParentID = 1, Avatar = "../shared/web/treelist/people/3.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 5, Name = "Sean Rusell", Title = "Financial Manager", Expanded = true, ParentID = 3, Avatar = "../shared/web/treelist/people/5.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 6, Name = "Steven North", Title = "Senior Manager", Expanded = false, ParentID = 3, Avatar = "../shared/web/treelist/people/6.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 7, Name = "Michelle Hudson", Title = "Operations Manager", Expanded = true, ParentID = 2, Avatar = "../shared/web/treelist/people/7.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 8, Name = "Andrew Berry", Title = "Team Lead", ParentID = 5, Avatar = "../shared/web/treelist/people/8.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 9, Name = "Jake Miller", Title = "Junior Accountant", ParentID = 5, Avatar = "../shared/web/treelist/people/9.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 10, Name = "Austin Piper", Title = "Accountant", ParentID = 5, Avatar = "../shared/web/treelist/people/10.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 11, Name = "Dilyana Newman", Title = "Accountant", ParentID = 5, Avatar = "../shared/web/treelist/people/11.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 12, Name = "Eva Andrews", Title = "Team Lead", ParentID = 6, Avatar = "../shared/web/treelist/people/12.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 13, Name = "Kaya Nilsen", Title = "Financial Specialist", ParentID = 6, Avatar = "../shared/web/treelist/people/13.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 16, Name = "Lillian Carr", Title = "Operator", ParentID = 7, Avatar = "../shared/web/treelist/people/17.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 17, Name = "David Henderson", Title = "Team Lead", ParentID = 7, Avatar = "../shared/web/treelist/people/16.jpg" });

            return Json(new
            {
                Data = source
            });
        }
    }
}