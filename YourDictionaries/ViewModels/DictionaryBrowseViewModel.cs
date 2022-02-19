using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using YourDictionaries.Commands;
using YourDictionaries.Domain.Models;
using YourDictionaries.EntityFramework;
using YourDictionaries.EntityFramework.DataServices;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionaries.State;

namespace YourDictionaries.ViewModels
{
    public class DictionaryBrowseViewModel : ViewModelBase
    {
        public ICommand NavigateAddPhrase { get; set; }
        public ObservableCollection<DictionaryViewModel> _dictionaries;
        public ObservableCollection<DictionaryViewModel> Dictionaries
        {
            get => _dictionaries;
            set
            {
                _dictionaries = value;
                OnPropertyChanged(nameof(Dictionaries));
            }
        }
        private DictionaryViewModel _selectedDictionary;

        public DictionaryViewModel SelectedDictionary
        {
            get { return _selectedDictionary; }
            set
            {
                _selectedDictionary = value;
                OnPropertyChanged(nameof(SelectedDictionary));
            }
        }

        private PhraseViewModel _selectedPhrase;

        public PhraseViewModel SelectedPhrase
        {
            get { return _selectedPhrase; }
            set
            {
                _selectedPhrase = value;
                OnPropertyChanged(nameof(SelectedPhrase));
            }
        }


        private readonly NavigationState _navigationState;

        public DictionaryBrowseViewModel(NavigationState navigationState)
        {
            _navigationState = navigationState;
            NavigateAddPhrase = new NavigateCommand<AddPhraseViewModel>(_navigationState, () => new AddPhraseViewModel(navigationState));
            IDictionaryDataService dictionaryDataService = new DictionaryDataService(new AppDbContextFactory());
            dictionaryDataService.GetDictionaries().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Dictionaries = new ObservableCollection<DictionaryViewModel>(task.Result.Select(d => new DictionaryViewModel(d)));
                }
                else
                {
                    MessageBox.Show(task.Exception.Message, "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
