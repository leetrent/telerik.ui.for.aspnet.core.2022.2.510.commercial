using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class StepperController : Controller
    {
        [Demo]
        public IActionResult Keyboard_Navigation(bool selectOnFocus)
        {
            var model = new StepperViewModel();

            model.SelectOnFocus = (selectOnFocus == false) ? false : true;

            return View(model);
        }
    }
}