using System;
using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Examples.Models.Form;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : BaseController
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View(new FormItemsViewModels()
            {
                TextBox = "John Doe",
                NumericTextBox = 2,
                MaskedTextBox = "21313",
                DatePicker = new DateTime(2020, 5, 7),
                DateTimePicker = new DateTime(2020, 5, 7, 9, 1, 0),
                Switch = false,
                RadioGroup = "1",
                CheckBoxGroup = new string[] { "1", "2" },
                ComboBox = "1",
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Tag_Helper(FormItemsViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return View(model);
            }
        }
    }
}