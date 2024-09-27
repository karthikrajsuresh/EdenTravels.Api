using System.ComponentModel.DataAnnotations;

namespace EdenTravels.Api.DTOs
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }

        [Required]
        public int BookingID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsSuccessful { get; set; }
    }
}