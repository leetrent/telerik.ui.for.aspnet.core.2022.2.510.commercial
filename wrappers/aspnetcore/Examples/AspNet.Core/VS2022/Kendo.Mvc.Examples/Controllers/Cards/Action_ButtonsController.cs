using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class CardsController : Controller
    {
        [Demo]
        public IActionResult Action_Buttons()
        {
            return View();
        }
    }
}