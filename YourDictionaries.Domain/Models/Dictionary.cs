using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YourDictionaries.Domain.Models
{
    public class Dictionary : DomainObject
    {
        [Required]
        public string Name { get; set; }
        public virtual IEnumerable<Phrase> Phrases { get; set; }
    }
}
