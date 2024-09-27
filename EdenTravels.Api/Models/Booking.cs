using System;

namespace EdenTravels.Api.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int TourID { get; set; }
        public int UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public int BookingStatusID { get; set; }
        public int TotalParticipants { get; set; }
        public bool PassportConfirmed { get; set; }
        public bool VisaConfirmed { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? PaymentDate { get; set; }

        // Navigation properties
        public Tour Tour { get; set; }
        public User User { get; set; }
    }

}
