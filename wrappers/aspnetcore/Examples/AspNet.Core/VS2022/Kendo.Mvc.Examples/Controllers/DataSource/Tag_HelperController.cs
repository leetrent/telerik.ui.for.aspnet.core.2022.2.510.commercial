using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DataSourceController : Controller
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }

        public ActionResult TagHelper_Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }
    }
}
