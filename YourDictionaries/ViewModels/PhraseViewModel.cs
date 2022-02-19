using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.Domain.Models;

namespace YourDictionaries.ViewModels
{
    public class PhraseViewModel
    {
        public string Expression { get; set; }
        public string Meaning { get; set; }  //TODO: Change "meaning" to "definition"
        public string Translation { get; set; }
        public string Transcription { get; set; }
        public DictionaryViewModel AssignedDictionary { get; set; }

        public PhraseViewModel()
        {

        }
        // TODO: use automapper
        public PhraseViewModel(Phrase phrase)
        {
            Expression = phrase.Expression;
            Meaning = phrase.Meaning;
            Translation = phrase.Translation;
            Transcription = phrase.Transcription;
            AssignedDictionary = new DictionaryViewModel(phrase.Dictionary);
        }
    }
}
