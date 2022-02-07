using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using YourDictionaries.Models;

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
        private DictionaryViewModel _selectedDictionary;
        public DictionaryViewModel SelectedDictionary
        {
            get
            {
                return _selectedDictionary;
            }
            set
            {
                _selectedDictionary = value;
                OnPropertyChanged(nameof(SelectedDictionary));
            }
        }

        private PhraseEntryViewMode _selectedPhrase;
        public PhraseEntryViewMode SelectedPhrase
        {
            get
            {
                return _selectedPhrase;
            }
            set
            {
                _selectedPhrase = value;
                OnPropertyChanged(nameof(SelectedPhrase));
            }
        }
        public DictionaryBrowseViewModel()
        {
            _dictionaries = new ObservableCollection<DictionaryViewModel>();
            _dictionaries.Add(GenerateDictionary("Cars"));
            _dictionaries.Add(GenerateDictionary("Career"));
            _dictionaries.Add(GenerateDictionary("Books"));
            _dictionaries.Add(GenerateDictionary("TV Series"));
            //_selectedDictionary = _dictionaries[0];
        }

        private DictionaryViewModel GenerateDictionary(string dictionaryName)
        {
            Dictionary dic = new Dictionary(dictionaryName);
            switch (dictionaryName)
            {
                case "Cars":
                    dic.AddPhraseEntry(new PhraseEntry("Car", "Thing used to drive around", "car it is", "Автомобиль"));
                    dic.AddPhraseEntry(new PhraseEntry("Ignition", "Thing used to start a car", "ignition it is", "Зажигание"));
                    break;
                case "Career":
                    dic.AddPhraseEntry(new PhraseEntry("Paycheck", "Thing you get for your work", "paycheck", "Зарплата"));
                    dic.AddPhraseEntry(new PhraseEntry("weekend", "Your time to relax", "weekend", "Выходные"));
                    break;
                case "Books":
                    dic.AddPhraseEntry(new PhraseEntry("Crime and punishment", "famous book by Dostoevsky", "c and p", "Преступление и наказание"));
                    dic.AddPhraseEntry(new PhraseEntry("Idiot", "famous book by Griboedov", "idiot", "Идиот"));
                    break;
                case "TV Series":
                    dic.AddPhraseEntry(new PhraseEntry("Scrubs", "cool tv series from early 00s", "scrubs", "Клиника"));
                    dic.AddPhraseEntry(new PhraseEntry("Game of Thrones", "cool tv series from late 10s", "GoT", "Игра престолов"));
                    break;
            }
            return new DictionaryViewModel(dic);
        }
    }
}
