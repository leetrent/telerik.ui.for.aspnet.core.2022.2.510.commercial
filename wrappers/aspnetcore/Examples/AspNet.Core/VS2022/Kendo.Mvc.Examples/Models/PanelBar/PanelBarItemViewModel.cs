using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Models
{
    public class PanelBarItemViewModel

    {
        public string id { get; set; }
        public string text { get; set; }
        public string spriteCssClass { get; set; }
        public string imageUrl { get; set; }
        public bool expanded { get; set; }
        public bool hasChildren { get; set; }
        public IEnumerable<PanelBarItemViewModel> items { get; set; }

        public PanelBarItemViewModel Clone()
        {
            PanelBarItemViewModel clone = new PanelBarItemViewModel
            {
                id = this.id,
                imageUrl = this.imageUrl,
                spriteCssClass = this.spriteCssClass,
                text = this.text,
                expanded = this.expanded,
                hasChildren = this.hasChildren
            };
            return clone;
        }
    }
}