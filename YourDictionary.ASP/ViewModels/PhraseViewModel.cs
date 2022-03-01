using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourDictionary.ASP.ViewModels
{
    public class PhraseViewModel
    {
        public int Id { get; set; }
        public string Expression { get; set; }
        public string Definition { get; set; }
        public string Translation { get; set; }
        public string Transcription { get; set; }
        public DictionaryViewModel Dictionary { get; set; }
    }
}
