using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using YourDictionaries.Models;

namespace YourDictionaries.Exceptions
{
    public class PhraseEntryConflictException : Exception
    {
        public PhraseEntry ExistingEntry;
        public PhraseEntry IncomingEntry;
        public PhraseEntryConflictException(PhraseEntry existingEntry, PhraseEntry incomingEntry)
        {
            ExistingEntry = existingEntry;
            IncomingEntry = incomingEntry;
        }

        public PhraseEntryConflictException(string message, PhraseEntry existingEntry, PhraseEntry incomingEntry) : base(message)
        {
            ExistingEntry = existingEntry;
            IncomingEntry = incomingEntry;
        }

        public PhraseEntryConflictException(string message, Exception innerException, PhraseEntry existingEntry, PhraseEntry incomingEntry) : base(message, innerException)
        {
            ExistingEntry = existingEntry;
            IncomingEntry = incomingEntry;
        }
    }
}
