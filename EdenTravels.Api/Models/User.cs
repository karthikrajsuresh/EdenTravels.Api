using System;

namespace EdenTravels.Api.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int LoyaltyPoints { get; set; }
        public int PointsThreshold { get; set; }
        public string RewardDescription { get; set; }
        public DateTime DateJoined { get; set; }
    }
}