using Kendo.Mvc.Examples.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Telerik.Zip;
using Microsoft.AspNetCore.Http;
using Kendo.Mvc.Examples.Extensions;
using Newtonsoft.Json;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ZipLibraryController : Controller
    {
        private ISession _session;

        public ISession Session { get { return _session; } }

        public ZipLibraryController(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        [Demo]
        public ActionResult Index()
        {
            return View(Files);
        }

        public List<FileHelper> Files
        {
            get
            {
                if (Session.GetObjectFromJson<List<FileHelper>>("MyFiles") == null)
                {
                    Session.SetObjectAsJson("MyFiles", new List<FileHelper>());
                }

                return Session.GetObjectFromJson<List<FileHelper>>("MyFiles") as List<FileHelper>;
            }   
            set
            {
                Session.SetObjectAsJson("MyFiles", value);
            }
        }
        public ActionResult LoadZip(IFormFile zipfile)
        {
            List<FileHelper> zipFiles = new List<FileHelper>();

            int count = 0;

            //read  the data from the uploaded zip and return a collection of files to display in Grid
            using (ZipArchive archive = new ZipArchive(zipfile.OpenReadStream()))
            {
                List<ZipArchiveEntry> allEntries = archive.Entries.ToList();
                foreach (ZipArchiveEntry entry in allEntries)
                {
                    // skip the folders compressed into the zip file
                    if (entry.Length == 0)
                    {
                        continue;
                    }
                    FileHelper fileHelper = new FileHelper(); //use of custom FileHelper class in order to create "files" with the needed metadata to display in the grid
                    fileHelper.ID = count++;
                    fileHelper.CompressedSize = (int)entry.CompressedLength;
                    fileHelper.UncompressedSize = (int)entry.Length;
                    fileHelper.FileNameInZip = entry.Name;

                    byte[] data = new byte[entry.Length];

                    Stream entryStream = entry.Open();
                    BinaryReader reader = new BinaryReader(entryStream);
                    reader.Read(data, 0, data.Length);

                    

                    fileHelper.Data = data;

                    zipFiles.Add(fileHelper); //fill the session variable with the collection of "files"
                    Files = zipFiles;

                }
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Download(string fileId)
        {

            FileHelper fileHelper = Files.Where(i => i.ID == Convert.ToInt16(fileId)).First();
            byte[] data = fileHelper.Data;

            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, fileHelper.FileNameInZip);
        }
    }
}

