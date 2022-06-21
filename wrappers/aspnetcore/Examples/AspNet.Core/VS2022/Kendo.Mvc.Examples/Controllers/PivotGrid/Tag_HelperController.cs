using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PivotGridController : BaseController
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            return View();
        }
    }
}
