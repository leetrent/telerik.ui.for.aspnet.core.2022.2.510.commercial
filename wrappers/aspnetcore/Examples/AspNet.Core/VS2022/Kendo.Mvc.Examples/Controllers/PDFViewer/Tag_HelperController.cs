using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PDFViewerController : Controller
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }
    }
}