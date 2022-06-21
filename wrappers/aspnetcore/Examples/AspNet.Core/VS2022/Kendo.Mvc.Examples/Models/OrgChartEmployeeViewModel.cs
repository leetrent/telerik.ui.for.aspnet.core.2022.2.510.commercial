using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models
{
    public class OrgChartEmployeeViewModel
    {
        public int ID
        {
            get; set;
        }
        public int? ParentID
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        public string Group
        {
            get; set;
        }
        public bool? Expanded
        {
            get; set;
        }
        public bool hasChildren
        {
            get; set;
        }
        public string Avatar
        {
            get; set;
        }
    }
}