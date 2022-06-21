using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class LoaderController : BaseController
    {
        [Demo]
        public IActionResult Color_Variations()
        {
            return View();
        }
    }
}