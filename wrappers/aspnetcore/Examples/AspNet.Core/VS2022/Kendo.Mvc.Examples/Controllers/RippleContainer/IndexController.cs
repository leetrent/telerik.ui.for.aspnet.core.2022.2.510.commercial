using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class RippleContainerController : Controller
    {
        [Demo]
        public IActionResult Index()
        {
            ViewBag.Attendees = new List<string>
            {
                "Steven White",
                "Nancy King",
                "Nancy Davolio",
                "Robert Davolio",
                "Michael Leverling",
                "Andrew Callahan",
                "Michael Suyama"
            };

            return View();
        }
    }
}
