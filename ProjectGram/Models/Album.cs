using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Portada { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Foto> Fotos { get; set; }
    }
}
