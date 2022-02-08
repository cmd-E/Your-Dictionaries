using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YourDictionaries.DTOs
{
    public class DictionaryDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string DictionaryName { get; set; }
        public List<PhraseDTO> Phrases { get; set; }
    }
}
