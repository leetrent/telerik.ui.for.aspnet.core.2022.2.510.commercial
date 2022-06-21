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
        public ActionResult ForeignKeyColumnBinding()
        {            
            return View();
        }

        public ActionResult Categories()
        {
            IEnumerable<CategoryViewModel> categories;
            using (var dataContext = new SampleEntitiesDataContext())
            {
                 categories = dataContext.Categories
                            .Select(c => new CategoryViewModel
                            {
                                CategoryID = c.CategoryID,
                                CategoryName = c.CategoryName
                            })
                            .OrderBy(e => e.CategoryName).ToList();
            }
            return Json(categories);
        }
    }
}
