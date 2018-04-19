using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public string Mensaje { get; set; }
        public List<Album> listaAlbumes { get; set; }
    }
}
