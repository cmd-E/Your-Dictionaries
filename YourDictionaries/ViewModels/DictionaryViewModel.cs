using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using YourDictionaries.Domain.Models;

namespace YourDictionaries.ViewModels
{
    public class DictionaryViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<PhraseViewModel> Phrases { get; set; }
        public DictionaryViewModel()
        {

        }
        // TODO: use automapper
        //public DictionaryViewModel(Dictionary dictionary)
        //{
        //    Id = dictionary.Id;
        //    Name = dictionary.Name;
        //    Phrases = dictionary.Phrases.Select(p => new PhraseViewModel(p));
        //}
    }
}
