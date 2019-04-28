using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class Followed
    {
        public int Id { get; set; }
        //public User User { get; set; }
        //public int UserId { get; set; }
        public String ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Follows Follows { get; set; }
       
    }
}
