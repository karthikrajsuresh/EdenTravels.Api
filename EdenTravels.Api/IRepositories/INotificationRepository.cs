using EdenTravels.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IRepositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetNotificationsForUserAsync(int userId);
        Task SendNotificationAsync(Notification notification);
    }

}
