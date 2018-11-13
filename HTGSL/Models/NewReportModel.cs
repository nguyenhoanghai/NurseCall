using System;
using System.Collections.Generic;
using System.Text;

namespace HTGSL.Models
{
   public class NewReportModel
    {
        public DateTime Date { get; set; }
        public string strDate { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public double ProcessTime { get; set; }
        public double WaitingTime { get; set; }
        public string Area { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public int BedId { get; set; }
        public string Product { get; set; }
        public List<NewReportModel> Details { get; set; }
        public NewReportModel()
        {
            Details = new List<NewReportModel>();
        }
    }
}
