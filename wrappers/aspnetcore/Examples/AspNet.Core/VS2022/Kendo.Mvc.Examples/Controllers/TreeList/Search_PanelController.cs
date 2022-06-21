using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.TreeList;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeListController : Controller
    {
        [Demo]
        public ActionResult Search_Panel()
        {
            return View();
        }
    }
}