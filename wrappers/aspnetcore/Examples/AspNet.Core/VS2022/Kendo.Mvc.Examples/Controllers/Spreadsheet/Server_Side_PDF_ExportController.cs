using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.Web.Spreadsheet;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf.Export;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace Kendo.Mvc.Examples.Controllers.Spreadsheet
{
    public partial class SpreadsheetController : Controller
    {
        [Demo]
        public ActionResult Server_Side_Pdf_Export()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveAsPDF(string data, string activeSheet, PrintOptions options, string selection)
        {
            var workbook = Telerik.Web.Spreadsheet.Workbook.FromJson(data);
            var document = workbook.ToDocument();

            var provider = new PdfFormatProvider();
            provider.ExportSettings = new PdfExportSettings(options.Source, false);

            document.ActiveSheet = document.Worksheets.First(sheet => sheet.Name == activeSheet);

            foreach (var sheet in document.Worksheets)
            {
                var pageSetup = sheet.WorksheetPageSetup;

                pageSetup.PaperType = options.PaperSize;
                pageSetup.PageOrientation = options.Orientation;

                pageSetup.CenterHorizontally = options.CenterHorizontally;
                pageSetup.CenterVertically = options.CenterVertically;

                pageSetup.PrintOptions.PrintGridlines = options.PrintGridlines;

                pageSetup.Margins = options.Margins;
            }

            using (var stream = new MemoryStream())
            {
                if (selection != "" && options.Source.ToString() == "Selection")
                {
                    int[] rangeParams = selection.Split(',').Select(int.Parse).ToArray();
                    var topLeftRow = rangeParams[0];
                    var topLeftCow = rangeParams[1];
                    var bottomRightRow = rangeParams[2];
                    var bottomRightCol = rangeParams[3];
                    var range = new CellRange(topLeftRow, topLeftCow, bottomRightRow, bottomRightCol);
                    provider.ExportSettings = new PdfExportSettings(new List<CellRange>() { range });
                }
                provider.Export(document, stream);

                var mimeType = Telerik.Web.Spreadsheet.MimeTypes.PDF;
                return File(stream.ToArray(), mimeType, "Print.pdf");
            }
        }
    }
}
