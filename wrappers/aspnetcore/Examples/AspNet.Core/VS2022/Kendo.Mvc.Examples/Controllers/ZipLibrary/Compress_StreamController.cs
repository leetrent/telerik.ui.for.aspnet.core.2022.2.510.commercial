using System;
using System.IO;
using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Telerik.Zip;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ZipLibraryController : Controller
    {
        [Demo]
        public ActionResult Compress_Stream()
        {
            ViewBag.document = GetSampleDocument();
            ViewBag.text = "";
            ViewBag.size = "Compressed size: 0";

            return View();
        }

        public string GetSampleDocument()
        {
            XmlDocument document = new XmlDocument();

            document.Load(@"wwwroot/shared/web/ziplibrary/BasicTools.xml");

            if (document.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                document.RemoveChild(document.FirstChild);                
            }

            var output = BeautifyXML(document);

            return output;
        }

        public string BeautifyXML(XmlDocument document)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };
           
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {             
                document.Save(writer);
            }

            return sb.ToString();
        }

        [HttpPost]
        public JsonResult Process_Document(string content, string compression)
        {
            var decodedContent = Uri.UnescapeDataString(content);
            var memoryStream = new MemoryStream();

            CompressionSettings settings;
            switch (compression)
            {
                case "deflate":
                    settings = new DeflateSettings();
                    break;
                case "lzma":
                    settings = new LzmaSettings();
                    break;
                default:
                    settings = new StoreSettings();
                    break;
            }

            using (CompressedStream stream = new CompressedStream(memoryStream, StreamOperationMode.Write, settings))
            {
                byte[] decBytes = Encoding.UTF8.GetBytes(decodedContent);
                stream.Write(decBytes, 0, decBytes.Length);
            }

            var compressedContent = Convert.ToBase64String(memoryStream.ToArray());
            var compressedSize = compressedContent.Length.ToString();

            return Json(new { content = compressedContent, label = compressedSize });
        }
    }
}
