using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
	public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Paging()
        {
            return View(new PagerViewModel());
        }

        [Demo]
        [HttpPost]
        public ActionResult Paging(PagerViewModel pager)
        {
            return View(pager);
        }

        [HttpPost]
        public ActionResult Paging_Orders([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }
    }
}