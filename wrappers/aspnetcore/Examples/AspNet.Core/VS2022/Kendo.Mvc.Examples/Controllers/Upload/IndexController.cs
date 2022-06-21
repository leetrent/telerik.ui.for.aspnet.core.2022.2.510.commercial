using Kendo.Mvc.Examples.Models;
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
        public IActionResult Index(UploadOverviewModel model)
        {
            if (model.AllowedExtensions == null)
            {
                model = new UploadOverviewModel()
                {
                    AllowedExtensions = new string[] { "jpg", "pdf", "docx", "xlsx", "zip" },
                    IsLimited = false
                };
            }
           
            return View(model);
        }
    }
}
