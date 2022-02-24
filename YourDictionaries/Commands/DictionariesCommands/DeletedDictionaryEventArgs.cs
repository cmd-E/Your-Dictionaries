using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Commands.DictionariesCommands
{
    public class DeletedDictionaryEventArgs : EventArgs
    {
        public DictionaryViewModel DeletedDictionary { get; set; }
    }
}
