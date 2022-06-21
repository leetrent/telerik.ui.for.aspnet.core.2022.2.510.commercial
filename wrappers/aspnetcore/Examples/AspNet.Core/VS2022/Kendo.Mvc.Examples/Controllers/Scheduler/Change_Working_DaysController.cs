using Kendo.Mvc.Examples.Models.Scheduler;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController : Controller
    {
        [Demo]
        public IActionResult Change_Working_Days()
        {
            return View();
        }
    }
}
