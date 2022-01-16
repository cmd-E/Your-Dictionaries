using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace YourDictionaries.ViewModels
{
    class DictionaryBrowseViewModel : ViewModelBase
    {
        public ICommand AddDictionaryCommand;
        public ICommand RemoveDictionaryCommand;
        public ICommand EditDictionaryCommand;

        public ICommand AddPhraseCommand;
        public ICommand RemovePhraseCommand;
        public ICommand EditPhraseCommand;

        private readonly ObservableCollection<DictionaryViewModel> _dictionaries;
        public IEnumerable<DictionaryViewModel> Dictionaries => _dictionaries;
        public DictionaryBrowseViewModel()
        {
            _dictionaries = new ObservableCollection<DictionaryViewModel>();
            _dictionaries.Add(new DictionaryViewModel(new Models.Dictionary("Cars")));
            _dictionaries.Add(new DictionaryViewModel(new Models.Dictionary("Career")));
            _dictionaries.Add(new DictionaryViewModel(new Models.Dictionary("Books")));
            _dictionaries.Add(new DictionaryViewModel(new Models.Dictionary("TV Series")));
        }

    }
}
