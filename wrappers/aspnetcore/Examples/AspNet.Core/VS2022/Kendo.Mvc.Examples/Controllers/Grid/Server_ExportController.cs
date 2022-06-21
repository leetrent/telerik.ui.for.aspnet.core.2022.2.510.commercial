
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Examples.Models;
using Telerik.Documents.SpreadsheetStreaming;
using Kendo.Core.Export;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult Server_Export()
        {
            return View();
        }

        [HttpPost]
        public FileStreamResult ExportServer(IList<ExportColumnSettings> columnSettings, string format, string title, int[] selectedIds)
        {

            SpreadDocumentFormat exportFormat = format == "csv" ? exportFormat = SpreadDocumentFormat.Csv : exportFormat = SpreadDocumentFormat.Xlsx;
            Action<ExportCellStyle> cellStyle = new Action<ExportCellStyle>(ChangeCellStyle);
            Action<ExportRowStyle> rowStyle = new Action<ExportRowStyle>(ChangeRowStyle);
            Action<ExportColumnStyle> columnStyle = new Action<ExportColumnStyle>(ChangeColumnStyle);
            IEnumerable<OrderViewModel> rowsData;

            if (selectedIds != null && selectedIds.Length > 0)
            {
                rowsData = GetOrders().Where(x=> selectedIds.Contains(x.OrderID)).ToList();
            }
            else
            {
                rowsData = GetOrders();
            }

            string fileName = string.Format("{0}.{1}", title, format);
            string mimeType = Helpers.GetMimeType(exportFormat);

            Stream exportStream = exportFormat == SpreadDocumentFormat.Xlsx ?
                rowsData.ToXlsxStream(columnSettings, title, cellStyleAction: cellStyle, rowStyleAction: rowStyle, columnStyleAction: columnStyle) :
                rowsData.ToCsvStream(columnSettings);

            var fileStreamResult = new FileStreamResult(exportStream, mimeType);
            fileStreamResult.FileDownloadName = fileName;
            fileStreamResult.FileStream.Seek(0, SeekOrigin.Begin);

            return fileStreamResult;
        }

        private void ChangeCellStyle(ExportCellStyle e)
        {
            bool isHeader = e.Row == 0;
            SpreadCellFormat format = new SpreadCellFormat
            {
                ForeColor = isHeader ? SpreadThemableColor.FromRgb(50, 54, 58) : SpreadThemableColor.FromRgb(214, 214, 217),
                IsItalic = true,
                VerticalAlignment = SpreadVerticalAlignment.Center,
                WrapText = true,
                Fill = SpreadPatternFill.CreateSolidFill(isHeader ? new SpreadColor(93, 227, 0) : new SpreadColor(50, 54, 58))
            };
            e.Cell.SetFormat(format);
        }

        private void ChangeRowStyle(ExportRowStyle e)
        {
            e.Row.SetHeightInPixels(e.Index == 0 ? 80 : 30);
        }

        private void ChangeColumnStyle(ExportColumnStyle e)
        {
            double width = e.Name == "Product name" || e.Name == "Category Name" ? 250 : 100;
            e.Column.SetWidthInPixels(width);
        }
    }
}
