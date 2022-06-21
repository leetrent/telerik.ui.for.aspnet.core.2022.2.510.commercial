using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class AutoCompleteController : BaseController
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }
    }
}
