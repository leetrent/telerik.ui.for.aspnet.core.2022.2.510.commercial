using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Pdf;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WordsProcessingController : Controller
    {
        [Demo]
        public ActionResult Pdf_Export()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Download_Document_Pdf(IFormFile customDocument)
        {
            IFormatProvider<RadFlowDocument> fileFormatProvider = null;
            RadFlowDocument document = null;
            string fileDownloadName = "{0}.{1}";
            string convertTo = "pdf";

            if (customDocument != null && Regex.IsMatch(Path.GetExtension(customDocument.FileName), ".docx|.rtf|.html|.txt"))
            {
                switch (Path.GetExtension(customDocument.FileName))
                {
                    case ".docx":
                        fileFormatProvider = new DocxFormatProvider();
                        break;
                    case ".rtf":
                        fileFormatProvider = new RtfFormatProvider();
                        break;
                    case ".html":
                        fileFormatProvider = new HtmlFormatProvider();
                        break;
                    case ".txt":
                        fileFormatProvider = new TxtFormatProvider();
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
                fileFormatProvider = new DocxFormatProvider();
                string fileName = @"wwwroot/shared/web/wordsprocessing/SampleDocumentPDF.docx";
                using (FileStream input = new FileStream(fileName, FileMode.Open))
                {
                    document = fileFormatProvider.Import(input);
                }

                fileDownloadName = String.Format(fileDownloadName, "SampleDocument", convertTo);
            }

            PdfFormatProvider convertFormatProvider = new PdfFormatProvider();
            string mimeType = "application/pdf";

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
