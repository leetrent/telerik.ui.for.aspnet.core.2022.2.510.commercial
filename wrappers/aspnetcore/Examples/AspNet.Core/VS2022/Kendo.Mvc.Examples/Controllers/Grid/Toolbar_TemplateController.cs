using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
	public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Toolbar_Template()
        {
            return View();
        }

        public ActionResult ToolbarTemplate_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }

        public ActionResult ToolbarTemplate_Categories()
        {
            using (var dataContext = new SampleEntitiesDataContext())
            {
                var categories = dataContext.Categories
                            .Select(c => new CategoryViewModel
                            {
                                CategoryID = c.CategoryID,
                                CategoryName = c.CategoryName
                            })
                            .OrderBy(e => e.CategoryName);

                return Json(categories.ToList());
            }
        }
    }
}
