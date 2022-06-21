using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers.ColorPicker
{
    public partial class FlatColorPickerController : Controller
    {
        [Demo]
        public IActionResult Contrast_Tool()
        {
            return View();
        }
    }
}
