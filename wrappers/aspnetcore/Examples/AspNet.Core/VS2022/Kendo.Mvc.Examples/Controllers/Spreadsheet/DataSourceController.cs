using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Gantt;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        private ISpreadsheetProductService productService;

        public SpreadsheetController(
            ISpreadsheetProductService service)
        {
            productService = service;
        }

        [Demo]
        public ActionResult DataSource()
        {
            return View();
        }

        public ActionResult Data_Source_Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }

        public ActionResult Data_Source_Products_Submit(SpreadsheetSubmitViewModel model)
        {
            var result = new SpreadsheetSubmitViewModel()
            {
                Created = new List<SpreadsheetProductViewModel>(),
                Updated = new List<SpreadsheetProductViewModel>(),
                Destroyed = new List<SpreadsheetProductViewModel>()
            };

            if ((model.Created != null || model.Updated != null || model.Destroyed != null) && ModelState.IsValid)
            {
                if (model.Created != null)
                {
                    foreach (var created in model.Created)
                    {
                        productService.Create(created);
                        result.Created.Add(created);
                    }
                }

                if (model.Updated != null)
                {
                    foreach (var updated in model.Updated)
                    {
                        productService.Update(updated);
                        result.Updated.Add(updated);
                    }
                }

                if (model.Destroyed != null)
                {
                    foreach (var destroyed in model.Destroyed)
                    {
                        productService.Destroy(destroyed);
                        result.Destroyed.Add(destroyed);
                    }
                }

                return Json(result);
            }
            else
            {
                return StatusCode(400, "The models contain invalid property values.");
            }
        }
    }
}