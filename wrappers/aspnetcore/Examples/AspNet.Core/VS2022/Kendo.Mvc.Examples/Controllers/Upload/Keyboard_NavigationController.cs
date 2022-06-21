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
        public IActionResult Keyboard_Navigation()
        {
            return View();
        }
    }
}
