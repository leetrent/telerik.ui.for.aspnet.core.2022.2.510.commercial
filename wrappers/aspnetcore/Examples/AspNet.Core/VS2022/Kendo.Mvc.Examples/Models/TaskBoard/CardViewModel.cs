namespace Kendo.Mvc.Examples.Models.TaskBoard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CardViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
    }
}
