using Microsoft.AspNetCore.Mvc;
using System.IO;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Export;
using Telerik.Windows.Documents.Fixed.Model;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PdfProcessingController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Download_Document()
        {
            PdfFormatProvider formatProvider = new PdfFormatProvider();
            formatProvider.ExportSettings.ImageQuality = ImageQuality.High;

            byte[] renderedBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                RadFixedDocument document = CreatePdfDocument.CreateDocument();
                formatProvider.Export(document, ms);
                renderedBytes = ms.ToArray();
            }

            return File(renderedBytes, "application/pdf", "PdfDocument.pdf");
        }
    }
}
