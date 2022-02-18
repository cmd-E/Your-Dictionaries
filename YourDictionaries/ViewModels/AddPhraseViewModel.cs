using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using YourDictionaries.Commands;
using YourDictionaries.State;

namespace YourDictionaries.ViewModels
{
    public class AddPhraseViewModel : ViewModelBase
    {
        public AddPhraseViewModel(NavigationState navigationState)
        {
            NavigateDictionaryBrowse = new NavigateCommand<DictionaryBrowseViewModel>(navigationState, () => new DictionaryBrowseViewModel(navigationState));
        }
        public ICommand NavigateDictionaryBrowse { get; set; }
    }
}
