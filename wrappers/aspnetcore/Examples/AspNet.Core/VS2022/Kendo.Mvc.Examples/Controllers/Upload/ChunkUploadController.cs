using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers
{
	public partial class UploadController : Controller
	{
        public class ChunkMetaData
        {
            public string UploadUid { get; set; }
            public string FileName { get; set; }
            public string RelativePath { get; set; }
            public string ContentType { get; set; }
            public long ChunkIndex { get; set; }
            public long TotalChunks { get; set; }
            public long TotalFileSize { get; set; }
        }

        public class FileResult
        {
            public bool uploaded { get; set; }
            public string fileUid { get; set; }
        }

        [Demo]
        public ActionResult ChunkUpload()
        {
            return View();
        }

        public void AppendToFile(string fullPath, IFormFile content)
        {
            try
            {
                using (FileStream stream = new FileStream(fullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    content.CopyTo(stream);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Chunk_Upload_Save(IEnumerable<IFormFile> files, string metaData)
        {
            if (metaData == null)
            {
                return await Save(files);
            }

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(metaData));

            JsonSerializer serializer = new JsonSerializer();
            ChunkMetaData chunkData;
            using (StreamReader streamReader = new StreamReader(ms))
            {
                chunkData = (ChunkMetaData)serializer.Deserialize(streamReader, typeof(ChunkMetaData));
            }

            string path = String.Empty;
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    path = Path.Combine(WebHostEnvironment.WebRootPath, "App_Data", chunkData.FileName);

                    //AppendToFile(path, file);
                }
            }

            FileResult fileBlob = new FileResult();
            fileBlob.uploaded = chunkData.TotalChunks - 1<= chunkData.ChunkIndex;
            fileBlob.fileUid = chunkData.UploadUid;

            return Json(fileBlob);
        }

        public ActionResult Chunk_Upload_Remove(string[] fileNames)
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

        public async Task<ActionResult> Save(IEnumerable<IFormFile> files)
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
    }
}