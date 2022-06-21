using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class EditorController : Controller
    {
        [Demo]
        public IActionResult Table_Editing()
        {
            return View();
        }   
    }
}