using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using YourDictionaries.Domain.Models;
using YourDictionaries.EntityFramework.DataServices;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Commands.PhrasesCommands
{
    public class EditPhraseCommand : BaseCommand
    {
        private readonly EditPhraseViewModel _editPhraseViewModel;

        public EditPhraseCommand(EditPhraseViewModel editPhraseViewModel)
        {
            _editPhraseViewModel = editPhraseViewModel;
            _editPhraseViewModel.PropertyChanged += _editPhraseViewModel_PropertyChanged;
        }

        private void _editPhraseViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_editPhraseViewModel.Phrase) ||
                e.PropertyName == nameof(_editPhraseViewModel.Meaning))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_editPhraseViewModel.Phrase) &&
                   !string.IsNullOrEmpty(_editPhraseViewModel.Meaning);
        }
        public override void Execute(object parameter)
        {
            var appContextFactory = new EntityFramework.AppDbContextFactory();
            IPhrasesDataService phrasesDataService = new PhrasesDataService(appContextFactory);
            var phrase = new Phrase
            {
                Id = _editPhraseViewModel.PhraseId,
                Expression = _editPhraseViewModel.Phrase,
                Meaning = _editPhraseViewModel.Meaning,
                Transcription = _editPhraseViewModel.Transcription,
                Translation = _editPhraseViewModel.Translation,
                DictionaryId = _editPhraseViewModel.SelectedDictionary.Id
            };
            phrasesDataService.Update(phrase).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    MessageBox.Show($"{phrase.Expression} has been successfully edited", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(task.Exception.Message, $"Error occured while editing {phrase.Expression}", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
    }
}
