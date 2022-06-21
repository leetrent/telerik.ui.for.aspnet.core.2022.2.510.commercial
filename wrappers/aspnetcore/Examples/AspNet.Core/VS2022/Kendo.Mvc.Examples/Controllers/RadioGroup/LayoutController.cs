using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.RadioGroup
{
    public partial class RadioGroupController : Controller
    {
        [Demo]
        public IActionResult Layout(string layout, string labelPosition)
        {
            RadioGroupLayout layoutValue = RadioGroupLayout.Vertical;
            if (layout == "Horizontal")
            {
                layoutValue = RadioGroupLayout.Horizontal;
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
