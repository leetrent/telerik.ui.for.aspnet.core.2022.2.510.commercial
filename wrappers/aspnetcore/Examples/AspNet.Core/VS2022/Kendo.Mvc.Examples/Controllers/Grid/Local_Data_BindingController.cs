using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Local_Data_Binding()
        {
            var model = productService.Read();

            return View(model);
        }        
    }
}