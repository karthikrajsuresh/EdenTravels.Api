using System;

namespace EdenTravels.Api.Models
{
    public class Customization
    {
        public int CustomizationID { get; set; }
        public int TourID { get; set; }
        public string OptionName { get; set; }
        public decimal PriceAdjustment { get; set; }
        public string Description { get; set; }

        // Navigation property
        public Tour Tour { get; set; }
    }

}
