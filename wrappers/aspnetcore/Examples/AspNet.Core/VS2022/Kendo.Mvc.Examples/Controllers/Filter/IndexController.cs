using System;
using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FilterController : BaseController
    {
        public FilterController()
        {
        }

        [Demo]
        public IActionResult Index()
        {
            return View();
        }
    }
}
