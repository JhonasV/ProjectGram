using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class Comment
    {
        public int Id { get; set; }
        //public int? UserId { get; set; }
        public int? FotoId { get; set; }

        public string Text { get; set; }
        public DateTime Created_at { get; set; }
        public String ApplicationUserId { get; set; }
        public virtual User User { get; set; }
        public virtual Foto Foto { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual List<CommentLikes> CommentLikes { get; set; }
    }
}
