using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models.Scheduler
{
    public class SchedulerResourceModel
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public int? Parent { get; set; }
        public string Color { get; set; }
    }
}
