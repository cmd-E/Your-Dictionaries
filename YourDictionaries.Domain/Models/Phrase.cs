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
        public string Meaning { get; set; } //TODO: Change "meaning" to "definition"
        public string Translation { get; set; }
        public string Transcription { get; set; }
        public int DictionaryId { get; set; }
        public virtual Dictionary Dictionary { get; set; }
    }
}
