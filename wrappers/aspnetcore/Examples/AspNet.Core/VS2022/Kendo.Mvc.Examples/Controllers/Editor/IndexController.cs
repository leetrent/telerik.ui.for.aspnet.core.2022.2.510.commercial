using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class EditorController : Controller
    {
        [Demo]
        public IActionResult Index()
        {
            return View();
        }
        
        [Demo]
        public IActionResult ImageBrowser()
        {
            return View();
        }
    }
}