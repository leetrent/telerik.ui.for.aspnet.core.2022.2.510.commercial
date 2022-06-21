using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Aggregates()
        {
            return View();
        }
        
        public ActionResult Aggregates_Read([DataSourceRequest] DataSourceRequest request)
        {
            var products = productService.Read();

            return Json(products.ToDataSourceResult(request));
        }
    }
}