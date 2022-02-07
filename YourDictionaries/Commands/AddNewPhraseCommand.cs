using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.Services;

namespace YourDictionaries.Commands
{
    public class AddNewPhraseCommand : CommandBase
    {
        private readonly NavigationService _dictionaryBrowseNavigationService;

        public AddNewPhraseCommand(NavigationService DictionaryBrowseNavigationService)
        {
            _dictionaryBrowseNavigationService = DictionaryBrowseNavigationService;
        }

        public override void Execute(object parameter)
        {
            _dictionaryBrowseNavigationService.Navigate();
        }
    }
}
