using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using YourDictionaries.Models;

namespace YourDictionaries.ViewModels
{
    public class DictionaryViewModel : ViewModelBase
    {
        private readonly Dictionary _dictionary;
        public string DictionaryName => _dictionary.DictionaryName;
        private readonly ObservableCollection<PhraseEntryViewMode> _phrases;
        public IEnumerable<PhraseEntryViewMode> Phrases => _phrases;

        public DictionaryViewModel(Dictionary dictionary)
        {
            _dictionary = dictionary;
            _phrases = new ObservableCollection<PhraseEntryViewMode>();
            foreach (PhraseEntry phraseEntry in _dictionary.GetAllPhraseEntries())
            {
                _phrases.Add(new PhraseEntryViewMode(phraseEntry));
            }
        }
    }
}