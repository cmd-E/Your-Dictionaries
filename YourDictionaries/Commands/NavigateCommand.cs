using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.Services;
using YourDictionaries.Stores;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
