using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.SkeletonContainer
{
    public partial class SkeletonContainerController : Controller
    {
        [Demo]
        public IActionResult Grid_Integration()
        {
            return View();
        }
    }
}
