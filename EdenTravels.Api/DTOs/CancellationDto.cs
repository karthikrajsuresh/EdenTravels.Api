using System;
using System.ComponentModel.DataAnnotations;

namespace EdenTravels.Api.DTOs
{
    public class CancellationDto
    {
        public int CancellationID { get; set; }

        [Required]
        public int BookingID { get; set; }

        [Required]
        public DateTime CancellationDate { get; set; }

        [Required]
        [StringLength(255)]
        public string Reason { get; set; }

        public string Status { get; set; }  // Example values: "Pending", "Approved", "Rejected"
    }

}
