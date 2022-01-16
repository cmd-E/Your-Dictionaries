using YourDictionaries.Models;

namespace YourDictionaries.ViewModels
{
    public class DictionaryViewModel
    {
        private readonly Dictionary _dictionary;
        public string DictionaryName => _dictionary.DictionaryName;

        public DictionaryViewModel(Dictionary dictionary)
        {
            _dictionary = dictionary;
        }

    }
}