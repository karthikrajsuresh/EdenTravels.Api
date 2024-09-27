using System;
using System.ComponentModel.DataAnnotations;

namespace EdenTravels.Api.DTOs
{
    public class PromotionDto
    {
        public int PromotionID { get; set; }

        [Required]
        public int TourID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public decimal DiscountPercentage { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Description { get; set; }
    }
}
