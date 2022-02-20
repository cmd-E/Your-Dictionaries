using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using YourDictionaries.Commands;
using YourDictionaries.Commands.PhrasesCommands;
using YourDictionaries.EntityFramework.DataServices;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionaries.Services;
using YourDictionaries.State;

namespace YourDictionaries.ViewModels
{
    public class EditPhraseViewModel : ViewModelBase
    {
        public ICommand NavigateDictionaryBrowse { get; set; }
        public ICommand EditPhraseCommand { get; set; }
        private ObservableCollection<DictionaryViewModel> _dictionaries;
        public ObservableCollection<DictionaryViewModel> Dictionaries
        {
            get
            {
                return _dictionaries;
            }
            set
            {
                _dictionaries = value;
                OnPropertyChanged(nameof(Dictionaries));
            }
        }

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

        private string _phrase;

        public string Phrase
        {
            get { return _phrase; }
            set
            {
                _phrase = value;
                OnPropertyChanged(nameof(Phrase));
            }
        }
        //TODO: Change "meaning" to "definition"
        private string _meaning;
        public string Meaning
        {
            get { return _meaning; }
            set
            {
                _meaning = value;
                OnPropertyChanged(nameof(Meaning));
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

        // Id of edited phrase required for updating
        public int PhraseId { get; set; }

        public EditPhraseViewModel(NavigationState navigationState, PhraseViewModel phraseViewModelToEdit)
        {
            NavigateDictionaryBrowse = new NavigateCommand<DictionaryBrowseViewModel>(navigationState, () => new DictionaryBrowseViewModel(navigationState));
            EditPhraseCommand = new EditPhraseCommand(this);
            Phrase = phraseViewModelToEdit.Expression;
            Meaning = phraseViewModelToEdit.Meaning;
            Transcription = phraseViewModelToEdit.Transcription;
            Translation = phraseViewModelToEdit.Translation;
            PhraseId = phraseViewModelToEdit.Id;
            IDictionaryDataService dictionaryDataService = new DictionaryDataService(new EntityFramework.AppDbContextFactory());
            dictionaryDataService.GetDictionaries().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Dictionaries = new ObservableCollection<DictionaryViewModel>(task.Result.Select(d => Mapper.MyMapper.Map<DictionaryViewModel>(d)));
                    // Doesn't work if type: this.SelectedDictionary = dictionaryToAddPhrase
                    foreach (var dic in Dictionaries)
                    {
                        if (dic.Id == phraseViewModelToEdit.AssignedDictionary.Id)
                        {
                            SelectedDictionary = dic;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(task.Exception.Message, "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
