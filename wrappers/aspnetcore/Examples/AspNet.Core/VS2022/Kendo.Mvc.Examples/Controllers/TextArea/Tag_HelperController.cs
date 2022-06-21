using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TextAreaController : Controller
    {
        [Demo]
        public ActionResult Tag_Helper()
        {
            return View();
        }
    }
}