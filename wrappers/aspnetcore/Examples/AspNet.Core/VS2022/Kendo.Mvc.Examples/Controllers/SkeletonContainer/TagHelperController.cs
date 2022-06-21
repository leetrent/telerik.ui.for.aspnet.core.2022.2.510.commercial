using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.SkeletonContainer
{
    public partial class SkeletonContainerController : Controller
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }
    }
}
