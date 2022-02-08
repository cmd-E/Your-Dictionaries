﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YourDictionaries.DTOs
{
    public class PhraseDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Phrase { get; set; }
        public string Definition { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
        public DictionaryDTO AssignedDictionary { get; set; }
    }
}