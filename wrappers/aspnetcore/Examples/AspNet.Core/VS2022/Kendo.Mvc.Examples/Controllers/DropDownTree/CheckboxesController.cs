using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.DropDownTree
{
    public partial class DropDownTreeController : BaseController
    {
        [Demo]
        public ActionResult Checkboxes()
        {
            return View(new string[0]);
        }
    }
}
