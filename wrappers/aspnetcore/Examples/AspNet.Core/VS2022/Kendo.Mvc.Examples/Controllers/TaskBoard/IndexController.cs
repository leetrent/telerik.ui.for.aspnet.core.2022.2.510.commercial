using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Examples.Models.TaskBoard;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TaskBoardController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            ViewBag.Cards = GetCards();

            return View();
        }

        private static IList<CardViewModel> GetCards()
        {
            IList<CardViewModel> cards = new List<CardViewModel>()
            {
                new CardViewModel { ID = 1, Title = "Campaigns", Order = 1, Description = "Create a new landing page for campaign", Status ="todo", Color= "orange", Image = "taskboard-demo-illustrations-01.png" },
                new CardViewModel { ID = 2, Title = "Newsletters", Order = 2, Description = "Send newsletter", Status ="todo", Color= "orange", Image = "taskboard-demo-illustrations-02.png" },
                new CardViewModel { ID = 3, Title = "Ads Analytics", Order = 3, Description = "Review ads performance", Status ="todo", Color= "blue", Image = "taskboard-demo-illustrations-03.png" },
                new CardViewModel { ID = 4, Title = "SEO Analytics", Order = 4, Description = "Review SEO results", Status ="todo", Color= "blue", Image = "taskboard-demo-illustrations-04.png" },
                new CardViewModel { ID = 5, Title = "Customer Research", Order = 5, Description = "Interview focus groups", Status ="todo", Color= "green", Image = "taskboard-demo-illustrations-05.png" },
                new CardViewModel { ID = 6, Title = "Testimonials & Case Studies", Order = 6, Description = "Publish new case study", Status ="todo", Color= "orange", Image = "taskboard-demo-illustrations-06.png" },
                new CardViewModel { ID = 7, Title = "Content", Order = 7, Description = "Plan content for podcasts", Status ="todo", Color= "orange", Image = "taskboard-demo-illustrations-07.png" },
                new CardViewModel { ID = 8, Title = "Customer Journey", Order = 8, Description = "Update virtual classrooms' experience", Status ="todo", Color= "orange", Image = "taskboard-demo-illustrations-08.png" },
                new CardViewModel { ID = 9, Title = "Funnel Analytics", Order = 9, Description = "Funnel analysis", Status ="inProgress", Color= "blue", Image = "taskboard-demo-illustrations-09.png" },
                new CardViewModel { ID = 10, Title = "Customer Research", Order = 10, Description = "Refine feedback from user interviews", Status ="inProgress", Color= "orange", Image = "taskboard-demo-illustrations-10.png" },
                new CardViewModel { ID = 11, Title = "Campaigns", Order = 11, Description = "Collaborate with designers on new banners", Status ="inProgress", Color= "orange", Image = "taskboard-demo-illustrations-11.png" },
                new CardViewModel { ID = 12, Title = "Campaigns", Order = 12, Description = "Schedule social media for release", Status ="inProgress", Color= "blue", Image = "taskboard-demo-illustrations-12.png" },
                new CardViewModel { ID = 13, Title = "Customer Journey", Order = 13, Description = "Review shopping cart experience", Status ="done", Color= "green", Image = "taskboard-demo-illustrations-13.png" },
                new CardViewModel { ID = 14, Title = "Content", Order = 14, Description = "Publish new blogpost", Status ="done", Color= "green", Image = "taskboard-demo-illustrations-14.png" },
                new CardViewModel { ID = 15, Title = "Post-Release Party", Order = 15, Description = "Plan new release celebration", Status ="done", Color= "blue", Image = "taskboard-demo-illustrations-15.png" },
            };

            return cards;
        }
    }
}
