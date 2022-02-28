using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourDictionary.ASP.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Name was not provided")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password was not provided")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }
}
