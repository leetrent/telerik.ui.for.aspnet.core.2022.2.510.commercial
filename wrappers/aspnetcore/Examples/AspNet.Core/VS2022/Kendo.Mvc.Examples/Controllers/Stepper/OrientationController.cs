using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class StepperController : Controller
    {
        [Demo]
        public IActionResult Orientation(string orientation)
        {
            StepperOrientationType value = StepperOrientationType.Horizontal;

            if (orientation == "vertical")
            {
                value = StepperOrientationType.Vertical;
            }
            return View(value);
        }
    }
}