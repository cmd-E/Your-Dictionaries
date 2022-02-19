using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourDictionaries.Domain.Models;

namespace YourDictionaries.ViewModels
{
    public class DictionaryViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public IEnumerable<PhraseViewModel> Phrases { get; set; }
        public DictionaryViewModel()
        {

        }

        public DictionaryViewModel(Dictionary dictionary)
        {
            Name = dictionary.Name;
            Phrases = dictionary.Phrases.Select(p => new PhraseViewModel(p));
        }
    }
}
