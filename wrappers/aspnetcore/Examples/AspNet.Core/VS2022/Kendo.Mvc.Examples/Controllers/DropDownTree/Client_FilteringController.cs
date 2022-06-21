using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers.DropDownTree
{
    public partial class DropDownTreeController : BaseController
    {
        [Demo]
        public ActionResult Client_Filtering()
        {
            return View(new string[0]);
        }
    }
}