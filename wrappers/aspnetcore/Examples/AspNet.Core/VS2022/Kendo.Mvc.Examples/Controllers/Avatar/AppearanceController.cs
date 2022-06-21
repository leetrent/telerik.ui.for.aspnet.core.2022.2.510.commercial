using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class AvatarController : BaseController
    {
        [Demo]
        public IActionResult Appearance()
        {
            return View();
        }
    }
}
