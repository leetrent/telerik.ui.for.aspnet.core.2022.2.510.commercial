using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeViewController : BaseController
    {
        [Demo]
        public IActionResult Basic_Usage()
        {
            return View();
        }
    }
}