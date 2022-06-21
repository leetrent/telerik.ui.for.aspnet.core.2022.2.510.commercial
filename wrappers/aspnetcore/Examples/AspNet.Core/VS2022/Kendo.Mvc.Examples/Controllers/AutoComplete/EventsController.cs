using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class AutoCompleteController : BaseController
    {
        [Demo]
        public IActionResult Events()
        {
            return View();
        }
    }
}