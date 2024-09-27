using System.ComponentModel.DataAnnotations;

namespace EdenTravels.Api.DTOs
{
    public class BookingDto
    {
        public int BookingID { get; set; }

        [Required]
        public int TourID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public int BookingStatusID { get; set; }
        public int TotalParticipants { get; set; }

        public bool PassportConfirmed { get; set; }
        public bool VisaConfirmed { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public DateTime? PaymentDate { get; set; }
    }

}
