using System;

namespace EdenTravels.Api.Models
{
    public class ReportData
    {
        public int TotalBookings { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalTours { get; set; }
        public DateTime ReportGeneratedOn { get; set; }
    }
}
