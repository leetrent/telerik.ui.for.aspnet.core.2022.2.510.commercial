using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ImageEditorController : BaseController
    {
        [Demo]
        public IActionResult Events()
        {
            return View();
        }
    }
}