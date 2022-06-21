using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MenuController : BaseController
    {
        [Demo]
        public IActionResult Context_Menu()
        {
            return View();
        }

        public ActionResult WebMailData([DataSourceRequest] DataSourceRequest request)
        {
            return Json(WebMailDataRepository.WebMailData().ToDataSourceResult(request));
        }
    }
}
