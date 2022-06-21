using Microsoft.AspNetCore.Mvc;
using System.IO;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Microsoft.AspNetCore.Http;
using Telerik.Windows.Documents.Spreadsheet.Model;
using System;
using System.Text.RegularExpressions;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.TextBased.Csv;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.TextBased.Txt;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsm;

namespace Kendo.Mvc.Examples.Controllers.SpreadStreamProcessing
{
    public partial class SpreadProcessingController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Download_Document(IFormFile customDocument, string convertTo)
        {
            IWorkbookFormatProvider fileFormatProvider = null;
            IWorkbookFormatProvider convertFormatProvider = null;
            Workbook document = null;
            string mimeType = String.Empty;
            string fileDownloadName = "{0}.{1}";

            if (customDocument != null && Regex.IsMatch(Path.GetExtension(customDocument.FileName), ".xlsx|.csv|.txt|.xlsm"))
            {
                switch (Path.GetExtension(customDocument.FileName))
                {
                    case ".xlsx":
                        fileFormatProvider = new XlsxFormatProvider();
                        break;
                    case ".csv":
                        fileFormatProvider = new CsvFormatProvider();
                        break;
                    case ".txt":
                        fileFormatProvider = new TxtFormatProvider();
                        break;
                    case ".xlsm":
                        fileFormatProvider = new XlsmFormatProvider();
                        break;
                    default:
                        fileFormatProvider = null;
                        break;
                }

                document = fileFormatProvider.Import(customDocument.OpenReadStream());
                fileDownloadName = String.Format(fileDownloadName, Path.GetFileNameWithoutExtension(customDocument.FileName), convertTo);
            }
            else
            {
                fileFormatProvider = new XlsxFormatProvider();
                string fileName = @"wwwroot/shared/web/spreadprocessing/SampleDocument.xlsx";
                using (FileStream input = new FileStream(fileName, FileMode.Open))
                {
                    document = fileFormatProvider.Import(input);
                }

                fileDownloadName = String.Format(fileDownloadName, "SampleDocument", convertTo);
            }

            switch (convertTo)
            {
                case "xlsx":
                    convertFormatProvider = new XlsxFormatProvider();
                    mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case "csv":
                    convertFormatProvider = new CsvFormatProvider();
                    mimeType = "text/csv";
                    break;
                case "txt":
                    convertFormatProvider = new TxtFormatProvider();
                    mimeType = "text/plain";
                    break;
                case "pdf":
                    convertFormatProvider = new PdfFormatProvider();
                    mimeType = "application/pdf";
                    break;
                case "xlsm":
                    convertFormatProvider = new XlsmFormatProvider();
                    mimeType = "application/vnd.ms-excel.sheet.macroEnabled.12";
                    break;
                default:
                    convertFormatProvider = new TxtFormatProvider();
                    mimeType = "text/plain";
                    break;
            }

            byte[] renderedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                convertFormatProvider.Export(document, ms);
                renderedBytes = ms.ToArray();
            }

            return File(renderedBytes, mimeType, fileDownloadName);
        }

    }
}
