using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUserIdSend { get; set; }

        public int NotificationType { get; set; }

        public bool IsAlreadyReaded { get; set; } = false;
        public virtual ApplicationUser ApplicationUser { get; set; }
        //public virtual ApplicationUser ApplicationUserReceive { get; set; }
    }
}
