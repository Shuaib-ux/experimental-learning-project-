using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DevaEnglish.Data
{
    public class RegisterUser
    {
        [Required, EmailAddress, Display(Name = "Email")]
        public string Email { get; set; }

        [Required, Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required, StringLength(40, ErrorMessage = "The {0} must be at least {2} and max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Confirmation Password must match the Password")]
        public string ConfirmPassword { get; set; }
    }
}
