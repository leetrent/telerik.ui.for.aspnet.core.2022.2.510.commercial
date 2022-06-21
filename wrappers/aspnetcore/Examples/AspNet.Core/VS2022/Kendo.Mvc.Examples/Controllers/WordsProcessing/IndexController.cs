using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Http;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WordsProcessingController : Controller
    {
        private IProductService productService;

        public WordsProcessingController(
           IProductService service)
        {
            productService = service;
        }

        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Download_Document(IFormFile customDocument, string convertTo)
        {
            IFormatProvider<RadFlowDocument> fileFormatProvider = null;
            IFormatProvider<RadFlowDocument> convertFormatProvider = null;
            RadFlowDocument document = null;
            string mimeType = String.Empty;
            string fileDownloadName = "{0}.{1}";

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
                string fileName = @"wwwroot/shared/web/wordsprocessing/SampleDocument.docx";
                using (FileStream input = new FileStream(fileName, FileMode.Open))
                {
                    document = fileFormatProvider.Import(input);
                }

                fileDownloadName = String.Format(fileDownloadName, "SampleDocument", convertTo);
            }

            switch (convertTo)
            {
                case "docx":
                    convertFormatProvider = new DocxFormatProvider();
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case "rtf":
                    convertFormatProvider = new RtfFormatProvider();
                    mimeType = "application/rtf";
                    break;
                case "html":
                    convertFormatProvider = new HtmlFormatProvider();
                    mimeType = "text/html";
                    break;
                case "txt":
                    convertFormatProvider = new TxtFormatProvider();
                    mimeType = "text/plain";
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
