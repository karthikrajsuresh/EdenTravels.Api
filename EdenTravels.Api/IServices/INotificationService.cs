using EdenTravels.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IServices
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetNotificationsForUserAsync(int userId);
        Task SendNotificationAsync(NotificationDto notificationDto);
    }

}
