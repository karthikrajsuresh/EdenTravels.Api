using System;
using System.ComponentModel.DataAnnotations;

namespace EdenTravels.Api.DTOs
{
    public class FeedbackDto
    {
        public int FeedbackID { get; set; }

        [Required]
        public int TourID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comments { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public DateTime DateSubmitted { get; set; }
    }
}
