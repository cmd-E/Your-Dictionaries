using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourDictionary.ASP.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name was not provided")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password was not provided")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation password was not provided")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
