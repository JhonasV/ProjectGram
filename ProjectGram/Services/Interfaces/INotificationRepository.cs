using ProjectGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Services.Interfaces
{
    public interface INotificationRepository
    {
        Task<Boolean> SaveNotification(Notification notification);

        Task<List<Notification>> GetNotifications(string currentUserId);
    }
}
