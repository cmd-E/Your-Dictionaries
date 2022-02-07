using System;
using System.Collections.Generic;
using System.Text;

namespace YourDictionaries.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public MainViewModel()
        {
            CurrentViewModel = new DictionaryBrowseViewModel();
        }
    }
}
