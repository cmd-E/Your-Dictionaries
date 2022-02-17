using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YourDictionaries.Domain.Models
{
    public class Dictionary
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Phrase> Phrases { get; set; }
    }
}
