using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.TagHelpers;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class CheckBoxGroupController : Controller
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            var itemsList = new List<IInputGroupItem>()
            {
                new InputGroupItemModel ()
                {
                    Label = "Phone (SMS)",
                    CssClass = "custom",
                    Enabled = true,
                    Encoded = false,
                    Value = "one",
                    HtmlAttributes = new Dictionary<string,object>() { { "data-custom", "custom" } }
                },
                 new InputGroupItemModel ()
                {
                    Label = "E-mail",
                    CssClass = "custom",
                    Enabled = true,
                    Encoded = false,
                    Value = "two"
                },
                  new InputGroupItemModel ()
                {
                    Label = "None",
                    CssClass = "custom",
                    Enabled = true,
                    Encoded = false,
                    Value = "three",
                    HtmlAttributes = new Dictionary<string,object>() { { "data-custom", "custom" } }
                }
            };

            return View(new CheckBoxGroupViewModel() { Items = itemsList, CheckBoxGroupValue = new string[] { "two" } });
        }
    }
}