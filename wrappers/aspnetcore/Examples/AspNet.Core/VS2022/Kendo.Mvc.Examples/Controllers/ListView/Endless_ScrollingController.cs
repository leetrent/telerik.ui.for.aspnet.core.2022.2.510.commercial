using System.Collections.Generic;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ListViewController : BaseController
    {
        [Demo]
        public ActionResult Endless_Scrolling()
        {
            return View();
        }

        public ActionResult Endless_Scrolling_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetProducts().ToDataSourceResult(request));
        }
    }
}