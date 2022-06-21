using Kendo.Mvc.Examples.Models.Scheduler;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController
    {
        [Demo]
        public IActionResult Resources_Grouping_Hierarchical()
        {
            return View();
        }

        public virtual JsonResult Grouping_Hierarchical_Read([DataSourceRequest] DataSourceRequest request)
        {
            var firstRoomAttendees = new List<int>() { 1, 2 };
            var secondRoomAttendees = new List<int>() { 1, 3 };

            var meetings = meetingService.GetAll().ToList()
                .Where(m => (m.RoomID == 1 && m.Attendees.All(a => firstRoomAttendees.Contains(a))) ||
                            (m.RoomID == 2 && m.Attendees.All(a => secondRoomAttendees.Contains(a))));

            return Json(meetings.ToDataSourceResult(request));
        }

        public virtual JsonResult Grouping_Hierarchical_Destroy([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Delete(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Grouping_Hierarchical_Create([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Insert(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Grouping_Hierarchical_Update([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Update(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }
    }
}
