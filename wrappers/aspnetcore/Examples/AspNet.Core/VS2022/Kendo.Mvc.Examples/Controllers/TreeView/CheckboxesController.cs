using Microsoft.AspNetCore.Mvc;
namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeViewController : BaseController
    {
        [Demo]
        public ActionResult Checkboxes()
        {
            return View(new string[0]);
        }

        [HttpPost]
        public ActionResult Checkboxes(string[] checkedFiles)
        {
            checkedFiles = checkedFiles ?? new string[0];
            return View(checkedFiles);
        }
    }
}