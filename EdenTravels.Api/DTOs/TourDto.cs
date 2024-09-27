using System.ComponentModel.DataAnnotations;

namespace EdenTravels.Api.DTOs
{
    public class TourDto
    {
        public int TourID { get; set; }

        [Required]
        [StringLength(255)]
        public string TourName { get; set; }

        [Required]
        public int OrganizerID { get; set; }

        [Required]
        public string TourType { get; set; }

        [Required]
        public decimal BasePrice { get; set; }

        public decimal DynamicPrice { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        public bool GroupBookingAvailable { get; set; }
        public bool PassportRequired { get; set; }
        public bool VisaRequired { get; set; }

        public bool CustomizablePackage { get; set; }
    }
}