using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using YourDictionaries.Commands;
using YourDictionaries.Models;

namespace YourDictionaries.ViewModels
{
    public class AddPhraseViewModel : ViewModelBase
    {
        private readonly ObservableCollection<DictionaryViewModel> _dictionaries;
        public IEnumerable<DictionaryViewModel> Dictionaries => _dictionaries;
        private string _phrase;
        public string Phrase
        {
            get
            {
                return _phrase;
            }
            set
            {
                _phrase = value;
                OnPropertyChanged(nameof(Phrase));
            }
        }

        private string _definition;
        public string Definition
        {
            get
            {
                return _definition;
            }
            set
            {
                _definition = value;
                OnPropertyChanged(nameof(Definition));
            }
        }
        private string _transcription;
        public string Transcription
        {
            get
            {
                return _transcription;
            }
            set
            {
                _transcription = value;
                OnPropertyChanged(nameof(Transcription));
            }
        }

        private string _translation;
        public string Translation
        {
            get
            {
                return _translation;
            }
            set
            {
                _translation = value;
                OnPropertyChanged(nameof(Translation));
            }
        }

        private string _selectedDictionary;
        public string SelectedDictionary
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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddPhraseViewModel()
        {
            SubmitCommand = new AddNewPhraseCommand(this);
            _dictionaries = new ObservableCollection<DictionaryViewModel>();
            _dictionaries.Add(GenerateDictionary("Cars"));
            _dictionaries.Add(GenerateDictionary("Career"));
            _dictionaries.Add(GenerateDictionary("Books"));
            _dictionaries.Add(GenerateDictionary("TV Series"));
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
