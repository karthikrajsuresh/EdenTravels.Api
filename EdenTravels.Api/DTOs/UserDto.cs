using System.ComponentModel.DataAnnotations;

namespace EdenTravels.Api.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int LoyaltyPoints { get; set; }

        public int PointsThreshold { get; set; }

        public string RewardDescription { get; set; }
    }
}