using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YourDictionaries.Domain.Models
{
    public class Phrase : DomainObject
    {
        [Required]
        public string Expression { get; set; }
        [Required]
        public string Meaning { get; set; }
        public string Translation { get; set; }
        public string Transcription { get; set; }
        public Dictionary AssignedDictionary { get; set; }
    }
}
