namespace EdenTravels.Api.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }

        // Navigation property
        public Booking Booking { get; set; }
    }

}
