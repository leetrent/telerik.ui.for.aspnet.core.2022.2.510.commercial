using Kendo.Mvc.Examples.Models.Scheduler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController
    {
        [Demo]
        public IActionResult Restriction()
        {
            var meetings = new List<MeetingViewModel> {
                new MeetingViewModel {
                    MeetingID = 1,
                    Title = "Call Charlie about the project",
                    Start = new DateTime(2013,6,13,10,30,00 , DateTimeKind.Utc),
                    End = new DateTime(2013,6,13,11,30,00, DateTimeKind.Utc),
                    RoomID = 1,
                    Attendees = new [] { 1 }
                },
                new MeetingViewModel {
                    MeetingID = 2,
                    Title = "Performance review",
                    Start = new DateTime(2013,6,13,9,00,00 , DateTimeKind.Utc),
                    End = new DateTime(2013,6,13,12,30,00, DateTimeKind.Utc),
                    RoomID = 2,
                    Attendees = new [] { 2 }
                },
                new MeetingViewModel {
                    MeetingID = 3,
                    Title = "HR Lecture",
                    Start = new DateTime(2013,6,13,13,00,00 , DateTimeKind.Utc),
                    End = new DateTime(2013,6,13,14,30,00, DateTimeKind.Utc),
                    RoomID = 1,
                    Attendees = new [] { 2 }
                }
            };

            return View(meetings);
        }
    }
}
