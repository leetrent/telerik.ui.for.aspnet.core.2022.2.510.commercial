using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MediaPlayerController : Controller
    {
        [Demo]
        public ActionResult Playlist()
        {
            return View(GetVideos());
        }

        public ActionResult Videos_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetVideos().ToDataSourceResult(request));
        }

        private static IEnumerable<Video> GetVideos()
        {
            List<Video> videos = new List<Video>();

            videos.Add(new Video()
            {
                title = "Build HIPAA-Compliant Healthcare Apps Fast",
                poster = "https://img.youtube.com/vi/_S63eCewxRg/1.jpg",
                source = "https://www.youtube.com/watch?v=dyvxivS5EcI"
            });

            videos.Add(new Video()
            {
                title = "ProgressNEXT 2018 Highlights",
                poster = "https://img.youtube.com/vi/DYsiJRmIQZw/1.jpg",
                source = "https://www.youtube.com/watch?v=Gp7tcOcSKAU"
            });

            videos.Add(new Video()
            {
                title = "Kendo UI Testimonial",
                poster = "https://img.youtube.com/vi/gNlya720gbk/1.jpg",
                source = "https://www.youtube.com/watch?v=itoKeywVNBI"
            });

            videos.Add(new Video()
            {
                title = "Introducing Test Studio DevEdition",
                poster = "https://img.youtube.com/vi/rLtTuFbuf1c/1.jpg",
                source = "https://www.youtube.com/watch?v=A2rmIx9rPG0"
            });

            videos.Add(new Video()
            {
                title = "Progress Application Server OpenEdge",
                poster = "https://i.ytimg.com/vi/CpHKm2NruYc/1.jpg",
                source = "https://www.youtube.com/watch?v=3Ce11N9udR4&list=PLC679RvCan2BJ9HCdUyZhnhHKActnrape"
            });

            return videos;
        }
    }
}
