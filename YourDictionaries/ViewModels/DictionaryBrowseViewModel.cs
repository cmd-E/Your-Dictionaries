using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using YourDictionaries.Commands;
using YourDictionaries.Commands.DictionariesCommands;
using YourDictionaries.Commands.PhrasesCommands;
using YourDictionaries.Domain.Models;
using YourDictionaries.EntityFramework;
using YourDictionaries.EntityFramework.DataServices;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionaries.Services;
using YourDictionaries.State;

namespace YourDictionaries.ViewModels
{
    public class DictionaryBrowseViewModel : ViewModelBase
    {
        public ICommand NavigateAddPhrase { get; set; }
        public ICommand DeletePhraseCommand { get; set; }
        public ICommand NavigateEditPhrase { get; set; }
        public ICommand NavigateCreateDictionary { get; set; }
        public ICommand DeleteDictionaryCommand { get; set; }
        public ICommand NavigateEditDictionaryCommand { get; set; }
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
            NavigateAddPhrase = new NavigateCommand<AddPhraseViewModel>(_navigationState, () => new AddPhraseViewModel(navigationState, SelectedDictionary));
            NavigateEditPhrase = new NavigateCommand<EditPhraseViewModel>(_navigationState, () => new EditPhraseViewModel(navigationState, SelectedPhrase));
            DeletePhraseCommand = new DeletePhraseCommand(this);
            NavigateCreateDictionary = new NavigateCommand<CreateDictionaryViewModel>(_navigationState, () => new CreateDictionaryViewModel(navigationState));
            DeleteDictionaryCommand = new DeleteDictionaryCommand(this);
            NavigateEditDictionaryCommand = new NavigateCommand<EditDictionaryViewModel>(_navigationState, () => new EditDictionaryViewModel(navigationState, SelectedDictionary));
            Commands.DictionariesCommands.DeleteDictionaryCommand.DictionaryDeleted += DeleteDictionaryCommand_DictionaryDeleted;
            Commands.PhrasesCommands.DeletePhraseCommand.PhraseDeleted += DeletePhraseCommand_PhraseDeleted;
            IDictionaryDataService dictionaryDataService = new DictionaryDataService(new AppDbContextFactory());
            dictionaryDataService.GetDictionaries().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Dictionaries = new ObservableCollection<DictionaryViewModel>(task.Result.Select(d => Mapper.MyMapper.Map<DictionaryViewModel>(d)));
                }
                else
                {
                    MessageBox.Show(task.Exception.Message, "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void DeleteDictionaryCommand_DictionaryDeleted(object source, Commands.DictionariesCommands.DeletedDictionaryEventArgs args)
        {
            var dvm = args.DeletedDictionary;
            foreach (var dic in Dictionaries)
            {
                if (dic.Id == dvm.Id)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        Dictionaries.Remove(dvm);
                    });
                    break;
                }
            }
        }

        private void DeletePhraseCommand_PhraseDeleted(object source, DeletedPhraseEventAgrs args)
        {
            var pvm = args.DeletedPhrase;
            foreach (DictionaryViewModel dic in Dictionaries)
            {
                foreach (var item in dic.Phrases)
                {
                    if (item.Expression == pvm.Expression)
                    {
                        App.Current.Dispatcher.Invoke((Action)delegate
                        {
                            dic.Phrases.Remove(pvm);
                        });
                        break;
                    }
                }
            }
        }
    }
}
