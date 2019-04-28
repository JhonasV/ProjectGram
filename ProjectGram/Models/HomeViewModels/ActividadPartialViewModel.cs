using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models.HomeViewModels
{
    public class ActividadPartialViewModel
    {
        public List<Foto> Fotos { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Comment Comment { get; set; }
    }
}
