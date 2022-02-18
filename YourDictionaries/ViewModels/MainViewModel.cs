using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.State;

namespace YourDictionaries.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase SelectedViewModel => _navigationState.CurrentViewModel;
        private readonly NavigationState _navigationState;

        public MainViewModel(NavigationState navigationState)
        {
            _navigationState = navigationState;
            _navigationState.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }

    }
}
