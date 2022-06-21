using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class StepperController : Controller
    {
        [Demo]
        public IActionResult Operation_Modes(string mode)
        {
            var model = new StepperViewModel();

            model.Linear = (mode == "false") ? false : true;

            return View(model);
        }
    }
}