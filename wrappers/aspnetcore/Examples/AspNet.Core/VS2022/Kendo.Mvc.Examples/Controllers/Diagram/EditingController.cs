using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        [Demo]
        public ActionResult Editing()
        {
            return View();
        }
    }
}