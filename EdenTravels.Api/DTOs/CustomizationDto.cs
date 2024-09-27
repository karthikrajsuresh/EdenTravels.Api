using System.ComponentModel.DataAnnotations;

namespace EdenTravels.Api.DTOs
{
    public class CustomizationDto
    {
        public int CustomizationID { get; set; }

        [Required]
        public int TourID { get; set; }

        [Required]
        [StringLength(255)]
        public string OptionName { get; set; }

        [Required]
        public decimal PriceAdjustment { get; set; }

        public string Description { get; set; }
    }

}
