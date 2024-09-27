namespace EdenTravels.Api.DTOs
{
    public class ParticipantDto
    {
        public int ParticipantID { get; set; }
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }
    }

}
