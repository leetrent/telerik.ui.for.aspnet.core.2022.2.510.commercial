using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers.CheckBoxGroup
{
    public partial class CheckBoxGroupController : Controller
    {
        [Demo]
        public ActionResult Layout(string layout, string labelPosition)
        {
            CheckBoxGroupLayout layoutValue = CheckBoxGroupLayout.Vertical;
            if (layout == "Horizontal")
            {
                layoutValue = CheckBoxGroupLayout.Horizontal;
            }

            if (labelPosition == "before" || string.IsNullOrEmpty(labelPosition))
            {
                ViewBag.LabelPosition = "before";
            }
            else
            {
                ViewBag.LabelPosition = "after";
            }

            return View(layoutValue);
        }
    }
}
