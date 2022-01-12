using System;
using System.Collections.Generic;
using System.Text;

namespace YourDictionaries.Models
{
    /// <summary>
    /// Class which contains all phrases, words and its transcriptions, meanings, translations on certain topic
    /// </summary>
    public class Dictionary
    {
        /// <summary>
        /// Name of the dictionary
        /// </summary>
        public string DictionaryName { get; private set; }
        private readonly PhrasesList _phrasesList;
        public Dictionary(string dictionaryName)
        {
            DictionaryName = dictionaryName;
            _phrasesList = new PhrasesList();
        }

        public IEnumerable<PhraseEntry> GetAllPhraseEntries()
        {
            return _phrasesList.GetAllPhraseEntries();
        }

        public void AddPhraseEntry(PhraseEntry phraseEntry)
        {
            _phrasesList.AddPhraseEntry(phraseEntry);
        }
    }
}
