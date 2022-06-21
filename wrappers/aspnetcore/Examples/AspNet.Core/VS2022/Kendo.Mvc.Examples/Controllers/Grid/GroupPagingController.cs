using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers.Grid
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult GroupPaging()
        {
            return View();
        }
    }
}
