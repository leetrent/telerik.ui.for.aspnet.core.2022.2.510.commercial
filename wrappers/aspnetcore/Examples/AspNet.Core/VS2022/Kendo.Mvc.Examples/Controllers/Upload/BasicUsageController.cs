using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class UploadController : Controller
    {
        [Demo]
        public IActionResult BasicUsage()
        {
            return View();
        }

        [Demo]
        public ActionResult Submit(IEnumerable<IFormFile> files)
        {
            IEnumerable<string> fileInfo = new List<string>();

            if (files != null)
            {
                fileInfo = GetFileInfo(files);
            }

            return View("Result", fileInfo);
        }

        [Demo]
        public ActionResult Result()
        {
            return View();
        }

        private IEnumerable<string> GetFileInfo(IEnumerable<IFormFile> files)
        {
            List<string> fileInfo = new List<string>();

            foreach (var file in files)
            {
                var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));

                fileInfo.Add(string.Format("{0} ({1} bytes)", fileName, file.Length));
            }

            return fileInfo;
        }
    }
}