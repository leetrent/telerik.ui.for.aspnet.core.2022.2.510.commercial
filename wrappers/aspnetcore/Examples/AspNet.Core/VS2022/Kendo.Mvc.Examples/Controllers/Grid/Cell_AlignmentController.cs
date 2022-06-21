using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Cell_Alignment()
        {
            return View();
        }

        public ActionResult CellAlignment_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }
    }
}