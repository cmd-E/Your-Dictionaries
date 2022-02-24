using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using YourDictionaries.Commands;
using YourDictionaries.Commands.DictionariesCommands;
using YourDictionaries.State;

namespace YourDictionaries.ViewModels
{
    public class CreateDictionaryViewModel : ViewModelBase
    {

        public ICommand NavigateBrowseDictionaryCommand { get; set; }
        public ICommand CreateDictionaryCommand { get; set; }
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
        public CreateDictionaryViewModel(NavigationState navigationState)
        {
            NavigateBrowseDictionaryCommand = new NavigateCommand<DictionaryBrowseViewModel>(navigationState, () => new DictionaryBrowseViewModel(navigationState));
            CreateDictionaryCommand = new CreateDictionaryCommand(this);
        }
    }
}
