using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.Domain.Models;

namespace YourDictionaries.ViewModels
{
    public class PhraseViewModel
    {
        public int Id { get; set; }
        public string Expression { get; set; }
        public string Meaning { get; set; }  //TODO: Change "meaning" to "definition"
        public string Translation { get; set; }
        public string Transcription { get; set; }
        public DictionaryViewModel AssignedDictionary { get; set; }
    }
}
