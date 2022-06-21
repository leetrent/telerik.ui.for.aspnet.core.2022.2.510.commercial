using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DropDownListController : BaseController
    {
        [Demo]
        public ActionResult Appearance()
        {
            return View();
        }
    }
}