using System;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MenuController : BaseController
    {
        [Demo]
        public ActionResult Direction_TagHelper(String directionString)
        {
            MenuDirection value = MenuDirection.Bottom;

            if (directionString == "left")
            {
                value = MenuDirection.Left;
            }

            if (directionString == "right")
            {
                value = MenuDirection.Right;
            }

            if (directionString == "top")
            {
                value = MenuDirection.Top;
            }

            return View(value);
        }
    }
}
