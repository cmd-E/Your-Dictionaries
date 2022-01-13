using System;
using System.Collections.Generic;
using System.Text;

namespace YourDictionaries.Models
{
    /// <summary>
    /// Class which contains phrase and its meaning, transcription, translation
    /// </summary>
    public class PhraseEntry
    {
        /// <summary>
        /// The phrase to describe
        /// </summary>
        public string Phrase { get; private set; }
        /// <summary>
        /// Meaning of the phrase
        /// </summary>
        public string Definition { get; private set; }
        /// <summary>
        /// Transcription of the phrase
        /// </summary>
        public string Transcription { get; private set; }
        /// <summary>
        /// Translation of the phrase
        /// </summary>
        public string Translation { get; private set; }
        public PhraseEntry(string phrase, string definition, string transcription, string translation)
        {
            Phrase = phrase;
            Definition = definition;
            Transcription = transcription;
            Translation = translation;
        }
        public bool Conflicts(PhraseEntry phraseEntry)
        {
            return phraseEntry.Phrase == Phrase;
        }
    }
}
