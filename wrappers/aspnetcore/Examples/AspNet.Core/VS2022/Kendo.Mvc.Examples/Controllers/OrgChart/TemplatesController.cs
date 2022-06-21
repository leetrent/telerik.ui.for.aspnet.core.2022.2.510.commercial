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
        public ActionResult Templates()
        {
            return View();
        }
        public JsonResult TemplatesData([DataSourceRequest] DataSourceRequest request)
        {
            var source = new List<OrgChartEmployeeViewModel>();

            source.Add(new OrgChartEmployeeViewModel() { ID = 1, Name = "Gevin Bell", Title = "CEO", Expanded = true, Avatar = "../shared/web/treelist/people/1.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 2, Name = "Clevey Thrustfield", Title = "Operations Dpt. Team Lead", Expanded = true, ParentID = 1, Avatar = "../shared/web/treelist/people/2.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 3, Name = "Kendra Howell", Title = "CMO", Expanded = false, ParentID = 1, Avatar = "../shared/web/treelist/people/4.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 4, Name = "Sean Rusell", Title = "Financial Manager", Expanded = false, ParentID = 3, Avatar = "../shared/web/treelist/people/5.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 5, Name = "Steven North", Title = "Financial Manager", Expanded = false, ParentID = 3, Avatar = "../shared/web/treelist/people/6.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 6, Name = "Michelle Hudson", Title = "Operations Manager", Expanded = true, ParentID = 2, Avatar = "../shared/web/treelist/people/7.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 7, Name = "Andrew Berry", Title = "Accountant", ParentID = 4, Avatar = "../shared/web/treelist/people/8.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 8, Name = "Austin Piper", Title = "Accountant", ParentID = 4, Avatar = "../shared/web/treelist/people/10.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 9, Name = "Kaya Nilsen", Title = "Financial Specialist", ParentID = 5, Avatar = "../shared/web/treelist/people/13.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 10, Name = "Lillian Carr", Title = "Operator", ParentID = 6, Avatar = "../shared/web/treelist/people/17.jpg" });
            source.Add(new OrgChartEmployeeViewModel() { ID = 11, Name = "DavID Henderson", Title = "Operator", ParentID = 6, Avatar = "../shared/web/treelist/people/16.jpg" });

            return Json(new
            {
                Data = source
            });
        }
    }
}