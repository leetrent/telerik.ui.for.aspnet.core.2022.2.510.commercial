using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers
{
	public partial class UploadController : Controller
	{
        [Demo]
        public ActionResult Events()
		{
			return View();
		}

        public async Task<ActionResult> Events_Save(IEnumerable<IFormFile> files)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var physicalPath = Path.Combine(WebHostEnvironment.WebRootPath, "App_Data", fileName);

                    // The files are not actually saved in this demo
                    //using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    //{
                    //    await file.CopyToAsync(fileStream);
                    //}
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult Events_Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(WebHostEnvironment.WebRootPath, "App_Data", fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        // System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }
    }
}
