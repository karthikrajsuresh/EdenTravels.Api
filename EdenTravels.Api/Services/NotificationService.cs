using EdenTravels.Api.DTOs;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.IServices;
using EdenTravels.Api.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace EdenTravels.Api.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificationsForUserAsync(int userId)
        {
            var notifications = await _notificationRepository.GetNotificationsForUserAsync(userId);
            return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
        }

        public async Task SendNotificationAsync(NotificationDto notificationDto)
        {
            var notification = _mapper.Map<Notification>(notificationDto);
            await _notificationRepository.SendNotificationAsync(notification);
        }
    }

}
