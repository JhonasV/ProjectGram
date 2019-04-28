using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Services.Interfaces;

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
    }
}