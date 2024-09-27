using System;

namespace EdenTravels.Api.Models
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public int TourID { get; set; }
        public string Title { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        // Navigation property
        public Tour Tour { get; set; }
    }

}
