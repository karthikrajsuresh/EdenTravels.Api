using System.ComponentModel.DataAnnotations;

namespace EdenTravels.Api.DTOs
{
    public class NotificationDto
    {
        public int NotificationID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string Message { get; set; }

        public DateTime DateSent { get; set; }
    }
}
