using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class BreadcrumbController : BaseController
    {
        [Demo]
        public IActionResult Api()
        {
            return View();
        }
    }
}