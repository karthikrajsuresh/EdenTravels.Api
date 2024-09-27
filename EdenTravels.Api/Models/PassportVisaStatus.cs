namespace EdenTravels.Api.Models
{
    public class PassportVisaStatus
    {
        public int BookingID { get; set; }
        public bool PassportConfirmed { get; set; }
        public bool VisaConfirmed { get; set; }

        // Navigation property
        public Booking Booking { get; set; }
    }

}
