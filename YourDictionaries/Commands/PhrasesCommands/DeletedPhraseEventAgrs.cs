using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Commands.PhrasesCommands
{
    public class DeletedPhraseEventAgrs : EventArgs
    {
        public PhraseViewModel DeletedPhrase{ get; set; }
    }
}
