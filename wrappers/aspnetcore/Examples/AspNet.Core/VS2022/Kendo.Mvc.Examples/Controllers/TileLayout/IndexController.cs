using System;
using System.Collections.Generic;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.TileLayout
{
    public partial class TileLayoutController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            var visitorData = new List<VisitorConversionViewModel>()
            {
                new VisitorConversionViewModel(){ Value = 2000, Date = new DateTime(2020, 4, 1), Channel = "Organic Search", Conversion = 8232, Users = 70500 },
                new VisitorConversionViewModel(){ Value = 80000, Date = new DateTime(2020, 4, 5), Channel = "Direct", Conversion = 6574, Users = 24900 },
                new VisitorConversionViewModel(){ Value = 130000, Date = new DateTime(2020, 4, 10),Channel = "Referral", Conversion = 4932, Users = 20000 },
                new VisitorConversionViewModel(){ Value = 170000, Date = new DateTime(2020, 4, 15),Channel = "Social Media", Conversion = 2928, Users = 19500 },
                new VisitorConversionViewModel(){ Value = 190000, Date = new DateTime(2020, 4, 20),Channel = "Email", Conversion = 2456, Users = 18100 },
                new VisitorConversionViewModel(){ Value = 190000, Date = new DateTime(2020, 4, 30),Channel = "Other", Conversion = 1172, Users = 16540 }
            };

            return View(visitorData);
        }
    }
}