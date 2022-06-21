using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Encodings.Web;
using IOFile = System.IO.File;
using System.Text.RegularExpressions;

namespace Kendo.Mvc.Examples.Controllers
{
    public class SourceController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly HtmlEncoder _htmlEncoder;

        public SourceController(IHostingEnvironment hostingEnvironment, HtmlEncoder htmlEncoder)
        {
            _hostingEnvironment = hostingEnvironment;
            _htmlEncoder = htmlEncoder;
        }

        public ActionResult Index(string path)
        {
            if (String.IsNullOrEmpty(path) || (
                    !path.StartsWith("/Views") &&
                    !path.StartsWith("/Models") &&
                    !path.StartsWith("/content") &&
                    !path.StartsWith("/Helpers") &&
                    !path.StartsWith("/Controllers")))
            {
                return NotFound();
            }

            var mappedPath = _hostingEnvironment.ContentRootPath + path.Replace("/", "\\");

            if (!IOFile.Exists(mappedPath))
            {
                return NotFound();
            }

            if (path.StartsWith("/content") && path.EndsWith("html"))
            {
                return Content(IOFile.ReadAllText(mappedPath), "text/html");
            }

            var source = IOFile.ReadAllText(mappedPath);

            source = Regex.Replace(source, @"\@section scripts\s*{(\\n)*\s*<script", "<script", RegexOptions.Multiline);
            source = Regex.Replace(source, @"script>(\\n)*\s*}", "script>", RegexOptions.Multiline);

            source = Regex.Replace(source, @"<script\s*data-src", "<script src", RegexOptions.Multiline);

            source = Regex.Replace(source, @"\$\(document\)\.on\(""kendoReady"",", "$(document).ready(", RegexOptions.Multiline);

            return Content("<pre class='prettyprint'>" + _htmlEncoder.Encode(source) + "</pre>", "text/plain");
        }
    }
}
