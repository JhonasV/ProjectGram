using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String Name { get; set; }

        public String LastName { get; set; }

        public String Sex { get; set; }

        public DateTime BirthDay { get; set; }

        //Navigationals vars
        public string Avatar { get; set; }


        public virtual List<Foto> Foto { get; set; }
        public virtual List<Follows> Follows { get; set; }
        public virtual List<Followed> FollowedList { get; set; }
        public virtual List<Archive> Archives { get; set; }

        public virtual List<Notification> Notifications { get; set; }

    }
}
