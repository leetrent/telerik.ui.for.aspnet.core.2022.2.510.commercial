using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers.DropDownTree
{
    public partial class DropDownTreeController : BaseController
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
