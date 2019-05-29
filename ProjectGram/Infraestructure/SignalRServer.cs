using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using ProjectGram.Models;
using ProjectGram.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Infraestructure
{
    public class SignalRServer : Hub
    {

        private readonly ILikeRepository _likeRepository;
        private readonly IFotoRepository _fotoRepository;
        private readonly INotificationRepository _notificationRepository;
        //private readonly IUserRepository _userRepository;
        //private readonly IHttpContextAccessor _contextAccessor;
        public SignalRServer(
            ILikeRepository likeRepository,
            INotificationRepository notificationRepository,
            IFotoRepository fotoRepository,
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository
            )
        {
            _likeRepository = likeRepository;
            _notificationRepository = notificationRepository;
            _fotoRepository = fotoRepository;
            //_contextAccessor = httpContextAccessor;
            //_userRepository = userRepository;
        }
        public enum NotificationType
        {
            LIKE = 1,
            COMMENT = 2
        }
        public async Task SendNotifications(int FotoId, NotificationType type, string currentUserId)
        {
            int notificationType = 1;
            if (type.Equals(NotificationType.LIKE))
            {
                try
                {
                    var count = await _likeRepository.GetLikeCount(FotoId);
                    var foto = await _fotoRepository.GetFotoById(FotoId);
                    //var currentUser = await _userRepository.GetCurrentUser(_contextAccessor.HttpContext.User);
                    var notification = new Notification
                    {
                        ApplicationUserIdSend = currentUserId,
                        ApplicationUserId = foto.ApplicationUserId,
                        NotificationType = notificationType
                    };

                     //await _notificationRepository.SaveNotification(notification);

                    var likeNotification = new
                    {
                        FotoId,
                        count,
                        notificationType
                    };
                    await Clients.All.SendAsync("Notifications", likeNotification);
                }
                catch (Exception e)
                {

                    e.ToString();
                }
                
               


                
            }
        }
    }
}
