﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class Foto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Ruta { get; set; }

        //public int UserId { get; set; }
        public String ApplicationUserId { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "La foto es obligatoria")]
        public IFormFile Img { get; set; }

        //public User User { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Likes> Likes { get; set; }
        public List<Archive> Archives { get; set; }

    }
}
