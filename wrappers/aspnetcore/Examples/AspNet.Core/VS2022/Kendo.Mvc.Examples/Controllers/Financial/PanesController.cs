using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FinancialController : BaseController
    {
        [Demo]
        public IActionResult Panes()
        {
            return View();
        }
    }
}