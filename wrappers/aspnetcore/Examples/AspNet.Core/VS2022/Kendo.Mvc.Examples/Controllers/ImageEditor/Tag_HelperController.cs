using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ImageEditorController : BaseController
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }
    }
}