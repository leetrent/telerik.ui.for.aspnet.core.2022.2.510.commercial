using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.DateRangePicker
{
    public partial class DateRangePickerController : Controller
    {
        [Demo]
        public IActionResult Appearance()
        {
            return View();
        }
    }
}