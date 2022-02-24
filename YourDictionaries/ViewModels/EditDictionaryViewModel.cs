using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using YourDictionaries.Commands;
using YourDictionaries.Commands.DictionariesCommands;
using YourDictionaries.State;

namespace YourDictionaries.ViewModels
{
    public class EditDictionaryViewModel : ViewModelBase
    {
        public ICommand NavigateDictionaryBrowseCommand { get; set; }
        public ICommand EditDictionaryCommand { get; set; }
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public EditDictionaryViewModel(NavigationState navigationState, DictionaryViewModel dictionaryViewModel)
        {
            NavigateDictionaryBrowseCommand = new NavigateCommand<DictionaryBrowseViewModel>(navigationState, () => new DictionaryBrowseViewModel(navigationState));
            EditDictionaryCommand = new EditDictionaryCommand(this);
            Id = dictionaryViewModel.Id;
            Name = dictionaryViewModel.Name;
        }
    }
}
