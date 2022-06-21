using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PivotGridController : BaseController
    {
        [Demo]
        public ActionResult Local_Flat_Data_Binding()
        {
            var model = productService.Read();

            return View(model);
        }
    }
}
