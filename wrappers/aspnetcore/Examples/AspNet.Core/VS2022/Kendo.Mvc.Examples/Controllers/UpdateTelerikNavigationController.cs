using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public class UpdateTelerikNavigationController : BaseController
    {
        [Home]
        public ActionResult Index()
        {
            return Json("Sorry, this page does not exist.");
        }
    }
}