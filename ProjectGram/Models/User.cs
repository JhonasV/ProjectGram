using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo NickName es obligatorio")]
        public String NickName { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage = "El campo Password es obligatorio")]
        public String Password { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public String Apellido { get; set; }

        public String Sexo { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio")]
        public DateTime FNacimiento { get; set; }

        public string Avatar { get; set; }
    }
}
