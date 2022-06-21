using Kendo.Mvc.Examples.Models.TreeList;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeListController : Controller
    {
        [Demo]
        public ActionResult Filter_Row()
        {
            return View();
        }

        public List<string> FilterRow_Positions()
        {
            var result = GetDirectory().Select(e => e.Position).Distinct().ToList();

            return result;
        }
    }
}