using System;

namespace EdenTravels.Api.Models
{
    public class Cancellation
    {
        public int CancellationID { get; set; }
        public int BookingID { get; set; }
        public DateTime CancellationDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

        // Navigation property
        public Booking Booking { get; set; }
    }
}
