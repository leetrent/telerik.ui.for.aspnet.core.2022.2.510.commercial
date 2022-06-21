namespace Kendo.Mvc.Examples.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using Kendo.Core.Export;

    public class EditorImportController : Controller
    {
        public ActionResult Import(IFormFile file)
        {
            var settings = new EditorImportSettings();
            string htmlResult;
            switch (Path.GetExtension(file.FileName))
            {
                case ".docx":
                    htmlResult = EditorImport.ToDocxImportResult(file, settings);
                    break;
                case ".rtf":
                    htmlResult = EditorImport.ToRtfImportResult(file, settings);
                    break;
                default:
                    htmlResult = EditorImport.GetTextContent(file);
                    break;
            }

            return Json(new { html = htmlResult });
        }
    }
}
