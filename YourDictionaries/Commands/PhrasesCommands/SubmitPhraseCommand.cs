using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using YourDictionaries.Domain.Models;
using YourDictionaries.EntityFramework.DataServices;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Commands.PhrasesCommands
{
    public class SubmitPhraseCommand : BaseCommand
    {
        private readonly AddPhraseViewModel _addPhraseViewModel;

        public SubmitPhraseCommand(AddPhraseViewModel addPhraseViewModel)
        {
            _addPhraseViewModel = addPhraseViewModel;
            _addPhraseViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addPhraseViewModel.Phrase) &&
                   !string.IsNullOrEmpty(_addPhraseViewModel.Meaning);
        }
        public override void Execute(object parameter)
        {
            var appContextFactory = new EntityFramework.AppDbContextFactory();
            IPhrasesDataService phrasesDataService = new PhrasesDataService(appContextFactory);
            var phrase = new Phrase
            {
                Expression = _addPhraseViewModel.Phrase,
                Meaning = _addPhraseViewModel.Meaning,
                Transcription = _addPhraseViewModel.Transcription,
                Translation = _addPhraseViewModel.Translation
            };
            phrasesDataService.AddPhraseToDictionary(phrase, _addPhraseViewModel.SelectedDictionary.Id).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    MessageBox.Show($"{phrase.Expression} has been successfully submitted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(task.Exception.Message, $"Error occured while submitting {phrase.Expression}", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }


        private void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addPhraseViewModel.Phrase) ||
                e.PropertyName == nameof(_addPhraseViewModel.Meaning))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
