using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourDictionary.ASP.ViewModels
{
    public class DictionaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserViewModel User { get; set; }
        public List<PhraseViewModel> Phrases { get; set; }
    }
}
