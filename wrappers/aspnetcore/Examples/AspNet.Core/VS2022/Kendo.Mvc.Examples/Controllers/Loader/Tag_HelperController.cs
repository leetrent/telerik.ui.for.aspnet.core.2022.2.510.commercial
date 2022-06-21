using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.Loader
{
    public partial class LoaderController : BaseController
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }
    }
}