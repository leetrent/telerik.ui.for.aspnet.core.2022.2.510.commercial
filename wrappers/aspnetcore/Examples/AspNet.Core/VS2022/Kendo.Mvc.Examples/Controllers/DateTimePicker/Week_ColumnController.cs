using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DateTimePickerController : Controller
    {
        [Demo]
        public IActionResult Week_Column()
        {
            return View();
        }
    }
}
