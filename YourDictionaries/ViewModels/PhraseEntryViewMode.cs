using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.Models;

namespace YourDictionaries.ViewModels
{
    public class PhraseEntryViewMode : ViewModelBase
    {
        private readonly PhraseEntry _phraseEntry;

        public string Phrase => _phraseEntry.Phrase;
        public string Definition => _phraseEntry.Definition;
        public string Transcription => _phraseEntry.Transcription;
        public string Translation => _phraseEntry.Translation;
        public PhraseEntryViewMode(PhraseEntry phraseEntry)
        {
            _phraseEntry = phraseEntry;
        }
    }
}
