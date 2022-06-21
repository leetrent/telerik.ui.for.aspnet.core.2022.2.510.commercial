using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FilterController : BaseController
    {
        [Demo]
        public IActionResult Persist_State()
        {
            return View();
        }
    }
}
