using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.ViewModels;

namespace YourDictionaries.State
{
    public class NavigationState
    {
        public event Action CurrentViewModelChanged;
        private ViewModelBase _currentVeiwModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentVeiwModel; }
            set 
            {
                _currentVeiwModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
