using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public string Mensaje { get; set; }
        public string RegistradoMessage { get; set; }

        public Album Album { get; set; }
        public List<Album> listaAlbumes { get; set; }
    }
}
