using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ChatController : Controller
    {
        [Demo]
        public IActionResult Index()
        {
            return View();
        }
    }
}