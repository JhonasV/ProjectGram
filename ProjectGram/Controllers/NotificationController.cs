using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;
using ProjectGram.Services.Interfaces;
using static ProjectGram.Models.Enums.Enums;

namespace ProjectGram.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;

        public NotificationController(INotificationRepository notificationRepository, IUserRepository userRepository)
        {
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> GetNotifications()
        {
            var principalClaim = this.User;
            var currentUser = await _userRepository.GetCurrentUser(principalClaim);
            var notifications = await _notificationRepository.GetNotifications(currentUser.Id);
            return Ok(notifications);
        }

        public  async Task<IActionResult> SaveNotification(NotificationType notificationType, string userId)
        {
            var principalClaim = this.User;
            var currentUser = await _userRepository.GetCurrentUser(principalClaim);
            var notification = CreateNotificationObject(notificationType, userId, currentUser.Id);
            var isSaved = await _notificationRepository.SaveNotification(notification);

            return Ok(new { isSaved });
        }


        public Notification CreateNotificationObject(NotificationType notificationType, string userId, string currentUserId)
        {
            var notification = new Notification()
            {
                ApplicationUserIdSend = currentUserId,
                ApplicationUserId = userId,
                NotificationType = (int)notificationType

            };

            return notification;
        }
    }
}