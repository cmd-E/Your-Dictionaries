using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using YourDictionaries.EntityFramework.DataServices;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Commands.PhrasesCommands
{
    public class DeletePhraseCommand : BaseCommand
    {
        public delegate void PhraseDeletedEventHandler(object source, DeletedPhraseEventAgrs args);
        public static event PhraseDeletedEventHandler PhraseDeleted;
        private readonly DictionaryBrowseViewModel _dictionaryBrowseViewModel;

        public DeletePhraseCommand(DictionaryBrowseViewModel dictionaryBrowseViewModel)
        {
            _dictionaryBrowseViewModel = dictionaryBrowseViewModel;
        }
        public override void Execute(object parameter)
        {
            IPhrasesDataService phrasesDataService = new PhrasesDataService(new EntityFramework.AppDbContextFactory());
            if (_dictionaryBrowseViewModel.SelectedPhrase == null) return;
            phrasesDataService.Delete(_dictionaryBrowseViewModel.SelectedPhrase.Id).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    MessageBox.Show($"{_dictionaryBrowseViewModel.SelectedPhrase.Expression} has been successfully deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnPhraseDeleted(_dictionaryBrowseViewModel.SelectedPhrase);
                }
                else
                {
                    MessageBox.Show(task.Exception.Message, $"Error occured while deleting {_dictionaryBrowseViewModel.SelectedPhrase.Expression}", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }

        private void OnPhraseDeleted(PhraseViewModel pvm)
        {
            PhraseDeleted?.Invoke(this, new DeletedPhraseEventAgrs() { DeletedPhrase = pvm });
        }
    }
}
