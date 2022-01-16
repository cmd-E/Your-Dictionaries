using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace YourDictionaries.ViewModels
{
    public class AddPhraseViewModel : ViewModelBase
    {
        private string _phrase;
        public string Phrase
        {
            get
            {
                return _phrase;
            }
            set
            {
                _phrase = value;
                OnPropertyChanged(nameof(Phrase));
            }
        }

        private string _definition;
        public string Definition
        {
            get
            {
                return _definition;
            }
            set
            {
                _definition = value;
                OnPropertyChanged(nameof(Definition));
            }
        }
        private string _transcription;
        public string Transcription
        {
            get
            {
                return _transcription;
            }
            set
            {
                _transcription = value;
                OnPropertyChanged(nameof(Transcription));
            }
        }

        private string _translation;
        public string Translation
        {
            get
            {
                return _translation;
            }
            set
            {
                _translation = value;
                OnPropertyChanged(nameof(Translation));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddPhraseViewModel()
        {

        }
    }
}
