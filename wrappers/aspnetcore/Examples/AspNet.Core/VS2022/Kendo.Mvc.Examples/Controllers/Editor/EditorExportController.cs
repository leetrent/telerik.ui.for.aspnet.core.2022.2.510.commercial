namespace Kendo.Mvc.Examples.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using Kendo.Core.Export;

    public class EditorExportController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EditorExportController(IWebHostEnvironment environment)
        {
            this._hostingEnvironment = environment;
        }

        [HttpPost]
        public ActionResult Export(EditorExportData data)
        {
            var settings = new EditorDocumentsSettings();
            settings.HtmlImportSettings.LoadFromUri += HtmlImportSettings_LoadFromUri;

            try
            {
                return EditorExport.Export(data, settings);
            }
            catch
            {
                return RedirectToAction("import-export", "editor");
            }
        }

        private void HtmlImportSettings_LoadFromUri(object sender, Telerik.Windows.Documents.Flow.FormatProviders.Html.LoadFromUriEventArgs e)
        {
            var uri = e.Uri;
            var absoluteUrl = uri.StartsWith("http://") || uri.StartsWith("www.");

            if (!absoluteUrl)
            {
                var trimmedUri = uri.Trim().TrimStart(Path.AltDirectorySeparatorChar).Replace("aspnet-core" + Path.AltDirectorySeparatorChar.ToString(), "");
                var webRootPath = _hostingEnvironment.WebRootPath;
                var filePath = Path.Combine(webRootPath, trimmedUri);

                using (var fileStream = System.IO.File.OpenRead(filePath))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        e.SetData(memoryStream.ToArray());
                    }
                }
            }
        }
    }
}
