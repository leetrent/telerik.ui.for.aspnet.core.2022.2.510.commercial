using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Models
{
    public class RadioGroupSingleItem : IInputGroupItem
    {
        public IDictionary<string, object> HtmlAttributes { get; set; }
       
        public string CssClass { get; set; }
        
        public bool? Enabled { get; set; }
        
        public bool? Encoded { get; set; }
        
        public string Label { get; set; }
       
        public string Value { get; set; }        
    }
}