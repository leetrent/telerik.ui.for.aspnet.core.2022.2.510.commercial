using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MenuController : BaseController
    {
        [Demo]
        public ActionResult ContextMenu_Tag_Helper()
        {
            using (var northwind = GetContext())
            {
                return View();
            }
           
        }
        public ActionResult TagHelper_WebMailData([DataSourceRequest] DataSourceRequest request)
        {
            return Json(WebMailDataRepository.WebMailData().ToDataSourceResult(request));
        }
    }
}