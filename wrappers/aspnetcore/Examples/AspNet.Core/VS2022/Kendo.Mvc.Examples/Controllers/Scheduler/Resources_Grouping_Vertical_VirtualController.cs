using Kendo.Mvc.Examples.Models.Scheduler;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController
    {
        [Demo]
        public IActionResult Resources_Grouping_Vertical_Virtual()
        {
            return View();
        }
    }
}
