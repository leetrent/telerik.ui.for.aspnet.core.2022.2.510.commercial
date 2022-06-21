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
        public ActionResult Api()
		{
			return View();
		}

        public async Task<ActionResult> Api_Save(IEnumerable<IFormFile> files)
        {

            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var physicalPath = Path.Combine(WebHostEnvironment.WebRootPath, "App_Data", fileName);

                    // The files are not actually saved in this demo
                    //using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    //{
                    //    await file.CopyToAsync(fileStream);
                    //}
                }
            }

            return Content("");
        }

        public ActionResult Api_Remove(string[] fileNames)
        {

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(WebHostEnvironment.WebRootPath, "App_Data", fileName);

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        // System.IO.File.Delete(physicalPath);
                    }
                }
            }

            return Content("");
        }
    }
}
