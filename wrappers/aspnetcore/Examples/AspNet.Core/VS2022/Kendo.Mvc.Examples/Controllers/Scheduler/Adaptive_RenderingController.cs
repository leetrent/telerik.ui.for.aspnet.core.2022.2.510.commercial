using Kendo.Mvc.Examples.Models.Scheduler;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController
    {
        [Demo]
        public IActionResult Adaptive_Rendering()
        {
            return View();
        }
        public virtual JsonResult AdaptiveRendering_Meetings_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(meetingService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult AdaptiveRendering_Meetings_Destroy([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Delete(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult AdaptiveRendering_Meetings_Create([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Insert(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult AdaptiveRendering_Meetings_Update([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Update(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }
    }
}
