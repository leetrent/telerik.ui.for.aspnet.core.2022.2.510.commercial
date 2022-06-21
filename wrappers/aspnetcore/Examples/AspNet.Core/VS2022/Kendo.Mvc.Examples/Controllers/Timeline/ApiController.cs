using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Timeline : BaseController
    {
        [Demo]
        public ActionResult Api()
        {
            return View();
        }
    }
}
