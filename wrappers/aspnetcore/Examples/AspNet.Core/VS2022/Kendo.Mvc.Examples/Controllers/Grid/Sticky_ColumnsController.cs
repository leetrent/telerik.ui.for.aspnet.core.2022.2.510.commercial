using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Sticky_Columns()
        {
            return View();
        }

        public ActionResult StickyColumns_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }
    }
}