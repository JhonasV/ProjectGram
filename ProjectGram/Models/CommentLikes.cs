using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class CommentLikes
    {
        public int Id { get; set; }

        public int? CommentId { get; set; }

        //public int? UserId { get; set; }
        public String ApplicationUserId { get; set; }
        //public int? FotoId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Comment Comment { get; set; }
        //public virtual User User { get; set; }
        public virtual CommentLikes CommentLike { get; set; }


    }
}
