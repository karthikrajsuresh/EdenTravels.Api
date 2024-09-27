using System;

namespace EdenTravels.Api.DTOs
{
    public class ReportDto
    {
        public int TotalBookings { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalTours { get; set; }
        public DateTime ReportGeneratedOn { get; set; }
    }
}
