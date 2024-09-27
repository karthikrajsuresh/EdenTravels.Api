using System;

namespace EdenTravels.Api.Models
{
    public class Tour
    {
        public int TourID { get; set; }
        public string TourName { get; set; }
        public int OrganizerID { get; set; }
        public string TourType { get; set; }
        public decimal BasePrice { get; set; }
        public decimal DynamicPrice { get; set; }
        public int Duration { get; set; }
        public int MaxCapacity { get; set; }
        public bool GroupBookingAvailable { get; set; }
        public bool PassportRequired { get; set; }
        public bool VisaRequired { get; set; }
        public bool CustomizablePackage { get; set; }
    }
}