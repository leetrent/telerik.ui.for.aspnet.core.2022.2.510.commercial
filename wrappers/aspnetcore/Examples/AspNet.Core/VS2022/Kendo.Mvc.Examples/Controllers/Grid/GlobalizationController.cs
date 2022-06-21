using System.Globalization;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!string.IsNullOrEmpty(context.HttpContext.Request.Query["culture"]))
            {
                CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(context.HttpContext.Request.Query["culture"]);
            }
            base.OnActionExecuting(context);
        }

        [Demo]
        public ActionResult Globalization()
        {
            return View();
        }

        public ActionResult Globalization_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Globalization_Create([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (product != null && ModelState.IsValid)
            {
                productService.Create(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Globalization_Update([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (product != null && ModelState.IsValid)
            {
                productService.Update(product);
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpPost]
        public ActionResult Globalization_Destroy([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (product != null)
            {
                productService.Destroy(product);
            }

            return Json(ModelState.ToDataSourceResult());
        }
    }
}
