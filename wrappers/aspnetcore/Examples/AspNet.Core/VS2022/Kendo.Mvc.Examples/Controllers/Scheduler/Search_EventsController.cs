using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models.Scheduler;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController
    {
        [Demo]
        public IActionResult Search_Events()
        {
            return View();
        }
    }
}
