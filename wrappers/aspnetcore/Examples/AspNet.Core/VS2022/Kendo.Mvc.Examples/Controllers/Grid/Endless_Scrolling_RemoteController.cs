using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Endless_Scrolling_Remote()
        {
            return View();
        }
    }
}
