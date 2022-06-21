using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FilterController : BaseController
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }
    }
}
