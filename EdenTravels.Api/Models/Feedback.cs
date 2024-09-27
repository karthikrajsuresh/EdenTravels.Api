using System;

namespace EdenTravels.Api.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int TourID { get; set; }
        public int UserID { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public DateTime DateSubmitted { get; set; }

        // Navigation properties
        public Tour Tour { get; set; }
        public User User { get; set; }
    }
}
