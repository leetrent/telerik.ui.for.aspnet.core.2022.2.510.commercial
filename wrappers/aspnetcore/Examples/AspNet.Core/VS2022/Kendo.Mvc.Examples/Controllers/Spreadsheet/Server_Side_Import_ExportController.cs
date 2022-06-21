using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Web.Spreadsheet;

namespace Kendo.Mvc.Examples.Controllers.Spreadsheet
{
    public partial class SpreadsheetController : Controller
    {
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public SpreadsheetController(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        [Demo]
        public ActionResult Server_Side_Import_Export()
        {
            var path = Path.Combine("wwwroot/shared/web/spreadsheet/products.json");

            ViewBag.Sheets = JsonConvert.DeserializeObject<IEnumerable<SpreadsheetSheet>>(System.IO.File.ReadAllText(path));

            return View();
        }

        [HttpPost]
        public ActionResult Upload(IFormFile file)
        {

            var workbook = Workbook.Load(file.OpenReadStream(), Path.GetExtension(file.FileName));
            return Content(workbook.ToJson(), Telerik.Web.Spreadsheet.MimeTypes.JSON);
           
        }

        [HttpPost]
        public ActionResult Download(string data, string extension)
        {
            var workbook = Workbook.FromJson(data);
            using (var stream = new MemoryStream())
            {
                workbook.Save(stream, extension);

                var mimeType = Telerik.Web.Spreadsheet.MimeTypes.ByExtension[extension];
                return File(stream.ToArray(), mimeType, "Exported" + extension);
            }
        }
    }
}
