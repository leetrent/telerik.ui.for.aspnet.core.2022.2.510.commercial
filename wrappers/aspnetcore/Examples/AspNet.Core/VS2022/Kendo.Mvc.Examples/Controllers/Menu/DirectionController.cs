using System;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MenuController : BaseController
    {
        [Demo]
        public ActionResult Direction(String directionString)
        {
            if (string.IsNullOrEmpty(directionString))
            {
                ViewBag.Direction = "bottom";
            }
            else
            {
                ViewBag.Direction = directionString;
            }
            return View();
        }
    }
}
