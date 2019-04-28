using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public User UserSecundario { get; set; }
        public List<Foto> FotoList { get; set; }
        public List<User> UserList { get; set; }
        public string Mensaje { get; set; }
        public string RegistradoMessage { get; set; }
        public Foto Foto { get; set; }
        public Follows Follows { get; set; }
        public bool isFollow { get; set; }
        public Comment comment { get; set; }
        public List<Comment> Comments { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public ApplicationUser ApplcationUserSecond { get; set; }
    }
}
