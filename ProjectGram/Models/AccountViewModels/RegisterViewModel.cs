using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least 5 characters long", MinimumLength = 5)]

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and the confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The username must be at least 5 characters long", MinimumLength = 5)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        public String Name { get; set; }

        [Required]
        public String LastName { get; set; }

        public String Sex { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }
    }
}
