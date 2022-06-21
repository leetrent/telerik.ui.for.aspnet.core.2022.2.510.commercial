using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeViewController : BaseController
    {
        [Demo]
        public ActionResult Templates()
        {
            return View();
        }

        public ActionResult Read_TemplateData(string id)
        {
            IEnumerable<TreeViewItemViewModel> result;
            if (string.IsNullOrEmpty(id))
            {
                result = TreeViewRepository.GetProjectData().Select(o => o.Clone());
            }
            else
            {
                result = TreeViewRepository.GetChildren(id);
            }
            return Json(result);
        }

    }
}
