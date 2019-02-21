using System;
using System.Collections.Generic;
using System.Text;

namespace HTGSL.Models
{
    public class ReportModel
    {
        public string Date { get; set; }
        public string Shift { get; set; }
        public string Area { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public string User { get; set; }
        public string Start { get; set; }
        public string Process { get; set; }
        public string End { get; set; }
        public string ProcessTime { get; set; } 
        public string WattingTime { get; set; }
    } 

}
