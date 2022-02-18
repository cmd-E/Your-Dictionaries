using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using YourDictionaries.Commands;
using YourDictionaries.State;

namespace YourDictionaries.ViewModels
{
    public class DictionaryBrowseViewModel : ViewModelBase
    {
        private readonly NavigationState _navigationState;

        public DictionaryBrowseViewModel(NavigationState navigationState)
        {
            _navigationState = navigationState;
            NavigateAddPhrase = new NavigateCommand<AddPhraseViewModel>(_navigationState, () => new AddPhraseViewModel(navigationState));

        }
        public ICommand NavigateAddPhrase { get; set; }
    }
}
