using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;

namespace Kendo.Mvc.Examples.Models
{
    public class PrintOptions
    {
        public ExportWhat Source { get; set; }
        public PaperTypes PaperSize { get; set; }
        public PageOrientation Orientation { get; set; }
        public PrintMargins Margins { get; set; }
        public bool CenterHorizontally { get; set; }
        public bool CenterVertically { get; set; }
        public bool PrintGridlines { get; set; }
    }
}
