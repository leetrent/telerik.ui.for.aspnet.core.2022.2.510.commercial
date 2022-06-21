using Kendo.Mvc.Examples.Models.Scheduler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController
    {
        [Demo]
        public IActionResult Templates()
        {
            List<Projection> cinemaSchedule = new List<Projection> {
                new Projection {
                    Title = "Fast and furious 6",
                    Image = "fast-and-furious.jpg",
                    Imdb = "https://www.Imdb.com/title/tt1905041/",
                    Start = new DateTime(2013,6,13,17,00,00),
                    End= new DateTime(2013,6,13,18,30,00)
                },
                new Projection {
                    Title= "The Internship",
                    Image= "the-internship.jpg",
                    Imdb= "https://www.Imdb.com/title/tt2234155/",
                    Start= new DateTime(2013,6,13,14,00,00),
                    End= new DateTime(2013,6,13,15,30,00)
                },
                new Projection {
                    Title = "The Perks of Being a Wallflower",
                    Image =  "wallflower.jpg",
                    Imdb =  "https://www.Imdb.com/title/tt1659337/",
                    Start =  new DateTime(2013,6,13,16,00,00),
                    End =  new DateTime(2013,6,13,17,30,00)
                },
                new Projection {
                    Title = "The Help",
                    Image =  "the-help.jpg",
                    Imdb =  "https://www.Imdb.com/title/tt1454029/",
                    Start =  new DateTime(2013,6,13,12,00,00),
                    End =  new DateTime(2013,6,13,13,30,00)
                },
                new Projection {
                    Title = "Now You See Me",
                    Image =  "now-you-see-me.jpg",
                    Imdb =  "https://www.Imdb.com/title/tt1670345/",
                    Start =  new DateTime(2013,6,13,10,00,00),
                    End =  new DateTime(2013,6,13,11,30,00)
                },
                new Projection {
                    Title = "Fast and furious 6",
                    Image =  "fast-and-furious.jpg",
                    Imdb =  "https://www.Imdb.com/title/tt1905041/",
                    Start =  new DateTime(2013,6,13,19,00,00),
                    End =  new DateTime(2013,6,13,20,30,00)
                },
                new Projection {
                    Title = "The Internship",
                    Image =  "the-internship.jpg",
                    Imdb =  "https://www.Imdb.com/title/tt2234155/",
                    Start =  new DateTime(2013,6,13,17,30,00),
                    End =  new DateTime(2013,6,13,19,00,00)
                },
                new Projection {
                    Title = "The Perks of Being a Wallflower",
                    Image =  "wallflower.jpg",
                    Imdb =  "https://www.Imdb.com/title/tt1659337/",
                    Start =  new DateTime(2013,6,13,17,30,00),
                    End =  new DateTime(2013,6,13,19,00,00)
                },
                new Projection {
                    Title = "The Help",
                    Image =  "the-help.jpg",
                    Imdb =  "https://www.Imdb.com/title/tt1454029/",
                    Start =  new DateTime(2013,6,13,13,30,00),
                    End =  new DateTime(2013,6,13,15,00,00)
                },
                new Projection {
                    Title = "Now You See Me",
                    Image =  "now-you-see-me.jpg",
                    Imdb =  "https://www.Imdb.com/title/tt1670345/",
                    Start =  new DateTime(2013,6,13,12,30,00),
                    End =  new DateTime(2013,6,13,14,00,00)
                }};

            return View(cinemaSchedule);
        }
    }
}
