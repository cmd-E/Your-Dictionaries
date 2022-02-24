using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using YourDictionaries.EntityFramework.DataServices;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Commands.DictionariesCommands
{
    public class DeleteDictionaryCommand : BaseCommand
    {
        public delegate void PhraseDeletedEventHandler(object source, DeletedDictionaryEventArgs args);
        public static event PhraseDeletedEventHandler DictionaryDeleted;
        private readonly DictionaryBrowseViewModel _dictionaryBrowseViewModel; // TODO: pass only selected dictionary

        public DeleteDictionaryCommand(DictionaryBrowseViewModel dictionaryBrowseViewModel)
        {
            _dictionaryBrowseViewModel = dictionaryBrowseViewModel;
        }

        public override void Execute(object parameter)
        {
            IDictionaryDataService dictionaryDataService = new DictionaryDataService(new EntityFramework.AppDbContextFactory());
            dictionaryDataService.Delete(_dictionaryBrowseViewModel.SelectedDictionary.Id).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    MessageBox.Show($"{_dictionaryBrowseViewModel.SelectedDictionary.Name} has been deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnDictionaryDeleted(_dictionaryBrowseViewModel.SelectedDictionary);
                }
                else
                {
                    MessageBox.Show($"Error occured while deleting {_dictionaryBrowseViewModel.SelectedDictionary.Name}: {task.Exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void OnDictionaryDeleted(DictionaryViewModel dictionaryViewModel)
        {
            DictionaryDeleted?.Invoke(this, new DeletedDictionaryEventArgs { DeletedDictionary = dictionaryViewModel });
        }
    }
}
