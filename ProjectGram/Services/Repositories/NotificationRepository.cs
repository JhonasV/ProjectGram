using Microsoft.EntityFrameworkCore;
using ProjectGram.Models;
using ProjectGram.Models.Data;
using ProjectGram.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Services.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly GramDbContext _context;

        public NotificationRepository(GramDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetNotifications(string currentUserId)
        {
            var notifications = new List<Notification>();
            try
            {
                notifications = await _context.Notifications.Where(n => n.ApplicationUserId.Equals(currentUserId) && n.IsAlreadyReaded.Equals(false))
                    .Include(u => u.ApplicationUser)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return notifications;
        }

        public async Task<bool> SaveNotification(Notification notification)
        {
            var isNotificationAdded = false;
            try
            {
                await _context.Notifications.AddAsync(notification);
                await _context.SaveChangesAsync();
                isNotificationAdded = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isNotificationAdded;
        }
    }
}
