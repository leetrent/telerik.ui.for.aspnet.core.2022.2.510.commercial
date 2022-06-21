using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Timeline : BaseController
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            List<TimelineEventModel> events = new List<TimelineEventModel>();

            events.Add(new TimelineEventModel() {
                Title = "Barcelona \u0026 Tenerife",
                Subtitle = "May 25, 2008",
                Description = "Barcelona is an excellent place to discover world-class arts and culture. Bullfighting was officially banned several years ago, but the city remains rich with festivals and events. The sights in Barcelona are second to none. Don’t miss the architectural wonder, Casa Mila—otherwise known as La Pedrera. It’s a modernist apartment building that looks like something out of an expressionist painting. Make your way up to the roof for more architectural surprises. And if you like Casa Mila, you’ll want to see another one of Antoni Gaudi’s architectural masterpieces, Casa Batllo, which is located at the center of Barcelona.\r\nTenerife, one of the nearby Canary Islands, is the perfect escape once you’ve had your fill of the city. In Los Gigantes, life revolves around the marina.",
                EventDate = new System.DateTime(2008, 5, 25),
                AltField = "Arc de Triomf, Barcelona, Spain",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/Barcelona-and-Tenerife/Arc-de-Triomf,-Barcelona,-Spain_Liliya-Karakoleva.JPG?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Barcelona", url="https://en.wikipedia.org/wiki/Barcelona" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "United States East Coast Tour 1",
                Subtitle = "Feb 27, 2007",
                Description = "Touring the East Coast of the United States provides a massive range of entertainment and exploration. To take things in a somewhat chronological order, best to begin your trip in the north, checking out Boston’s Freedom Trail, Fenway Park, the Statue of Liberty, and Niagara Falls. Bring your raincoat to Niagara Falls, which straddles the boarder between Canada and the United States—the majestic sight might have you feeling misty in every sense of the word.",
                EventDate = new System.DateTime(2007, 2, 27),
                AltField = "Boston Old South Church",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/United-States/Boston-Old-South-Church_Ivo-Igov.JPG?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about New York City", url="https://en.wikipedia.org/wiki/New_York_City" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Malta, a Country of Кnights",
                Subtitle = "Jun 15, 2008",
                Description = "Home of the oldest-known human structures in the world, the Maltese archipelago is best described as an open-air museum. Malta, the biggest of the seven Mediterranean islands, is the cultural center of the three largest—only three islands that are fully inhabited.  If you’re into heavy metal—swords, armor and other medieval weaponry—you’ll love the Grandmaster’s Palace.",
                EventDate = new System.DateTime(2008, 6, 15),
                AltField = "Bibliotheca National Library Marie Lan Nguyen",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/Malta/Bibliotheca-National-Library_Marie-Lan-Nguyen.JPG?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Malta", url="https://en.wikipedia.org/wiki/Malta" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Wonders of Italy",
                Subtitle = "Jul 6, 2008",
                Description = "The Italian Republic is a history lover’s paradise with thousands of museums, churches and archaeological sites dating back to Roman and Greek times. Visitors will also find a hub for fashion and culture unlike anywhere else in the world. Explore Ancient history in Rome at the Colosseum and Rome’s Ruins.",
                EventDate = new System.DateTime(2008, 7, 6),
                AltField = "Basilica di San Pietro in Vaticano",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/Italy/Basilica-di-San-Pietro-in-Vaticano2_Lilia-Karakoleva.jpg?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Rome", url="https://en.wikipedia.org/wiki/Rome" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "The Best of Western Europe",
                Subtitle = "Aug 11, 2009",
                Description = "Tour the best of Western Europe and take in the sights of Munich, Frankfurt, Meinz, Bruxel, Amsterdam, and Vienna along the way. Discover the amazing world of plants at Frankfurt Palmengarten, the botanical gardens in Frankfurt.",
                EventDate = new System.DateTime(2009, 8, 11),
                AltField = "Austrian Parliament, Vienna, Austria",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/Western-Europe/Austrian-Parliament,-Vienna,-Austria_Gergana-Prokopieva.JPG?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Munich", url="https://en.wikipedia.org/wiki/Munich" }
                }
            });

            return Json(events);
        }
    }
}
