using System;
using System.Collections.Generic;
using System.Text;
using YourDictionaries.Exceptions;

namespace YourDictionaries.Models
{
    public class PhrasesList
    {
        /// <summary>
        /// List of words with transcriptions, meanings and translations
        /// </summary>
        private readonly List<PhraseEntry> _phraseEntries;
        public PhrasesList()
        {
            _phraseEntries = new List<PhraseEntry>();
        }
        /// <summary>
        /// Retrieves all phrase entries from the list
        /// </summary>
        /// <returns>List of all entries</returns>
        public IEnumerable<PhraseEntry> GetAllPhraseEntries()
        {
            return _phraseEntries;
        }
        /// <summary>
        /// Adds new phrase entry to the list
        /// </summary>
        /// <param name="phraseEntry">New phrase entry provided by user</param>
        /// <exception cref="PhraseEntryConflictException"></exception>
        public void AddPhraseEntry(PhraseEntry phraseEntry)
        {
            foreach (PhraseEntry entry in _phraseEntries)
            {
                if (entry.Conflicts(phraseEntry))
                {
                    throw new PhraseEntryConflictException(entry, phraseEntry);
                }
            }
            _phraseEntries.Add(phraseEntry);
        }
    }
}
