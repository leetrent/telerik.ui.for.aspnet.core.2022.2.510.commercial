using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MultiSelectController : BaseController
    {
        [Demo]
        public ActionResult Appearance()
        {
            return View();
        }
    }
}