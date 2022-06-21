using System;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Api()
        {
            return View();
        }
        
        public ActionResult Api_Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }
    }
}