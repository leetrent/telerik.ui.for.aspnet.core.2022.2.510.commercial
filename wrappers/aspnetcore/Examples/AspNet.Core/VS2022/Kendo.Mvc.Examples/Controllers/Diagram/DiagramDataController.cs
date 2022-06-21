using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models.Diagram;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers.Diagram
{
    public class DiagramDataController : Controller
    {
        private DiagramShapeService shapeService;
        private DiagramConnectionService connectionService;

        public DiagramDataController()
        {
            shapeService = new DiagramShapeService();
            connectionService = new DiagramConnectionService();

        }

        protected override void Dispose(bool disposing)
        {
            shapeService.Dispose();
            connectionService.Dispose();

            base.Dispose(disposing);
        }

        public virtual JsonResult ReadShapes([DataSourceRequest] DataSourceRequest request)
        {
            return Json(shapeService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult DestroyShape([DataSourceRequest] DataSourceRequest request, OrgChartShape shape)
        {
            if (ModelState.IsValid)
            {
                shapeService.Delete(shape, ModelState);
            }

            return Json(new[] { shape }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult CreateShape([DataSourceRequest] DataSourceRequest request, OrgChartShape shape)
        {
            if (ModelState.IsValid)
            {
                shapeService.Insert(shape, ModelState);
            }

            return Json(new[] { shape }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult UpdateShape([DataSourceRequest] DataSourceRequest request, OrgChartShape shape)
        {
            if (ModelState.IsValid)
            {
                shapeService.Update(shape, ModelState);
            }

            return Json(new[] { shape }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult ReadConnections([DataSourceRequest] DataSourceRequest request)
        {
            return Json(connectionService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult DestroyConnection([DataSourceRequest] DataSourceRequest request, OrgChartConnection connection)
        {
            if (ModelState.IsValid)
            {
                connectionService.Delete(connection, ModelState);
            }

            return Json(new[] { connection }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult CreateConnection([DataSourceRequest] DataSourceRequest request, OrgChartConnection connection)
        {
            if (ModelState.IsValid)
            {
                connectionService.Insert(connection, ModelState);
            }

            return Json(new[] { connection }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult UpdateConnection([DataSourceRequest] DataSourceRequest request, OrgChartConnection connection)
        {
            if (ModelState.IsValid)
            {
                connectionService.Update(connection, ModelState);
            }

            return Json(new[] { connection }.ToDataSourceResult(request, ModelState));
        }
    }
}