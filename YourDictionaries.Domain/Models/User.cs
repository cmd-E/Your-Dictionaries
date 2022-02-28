using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YourDictionaries.Domain.Models
{
    public class User : DomainObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
