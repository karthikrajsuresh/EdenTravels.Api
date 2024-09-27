using System;

namespace EdenTravels.Api.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }

        // Navigation property
        public User User { get; set; }
    }

}
