using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class FotoViewerViewModel
    {
        public List<Foto> Fotos { get; set; }
        public ApplicationUser CurrentUser { get; set; }
    }
}
