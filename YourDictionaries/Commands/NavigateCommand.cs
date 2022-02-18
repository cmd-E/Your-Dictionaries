using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.State;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Commands
{
    public class NavigateCommand<T> : BaseCommand where T : ViewModelBase
    {
        private readonly NavigationState _navigationState;
        private readonly Func<T> _newViewModel;

        public NavigateCommand(NavigationState navigationState, Func<T> newViewModel)
        {
            _navigationState = navigationState;
            _newViewModel = newViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationState.CurrentViewModel = _newViewModel();
        }
    }
}
