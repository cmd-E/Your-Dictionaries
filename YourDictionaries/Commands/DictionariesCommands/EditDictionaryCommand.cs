using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using YourDictionaries.Domain.Models;
using YourDictionaries.EntityFramework.DataServices;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionaries.ViewModels;

namespace YourDictionaries.Commands.DictionariesCommands
{
    public class EditDictionaryCommand : BaseCommand
    {
        private readonly EditDictionaryViewModel _editDictionaryViewModel;

        public EditDictionaryCommand(EditDictionaryViewModel editDictionaryViewModel)
        {
            _editDictionaryViewModel = editDictionaryViewModel;
            _editDictionaryViewModel.PropertyChanged += _editDictionaryViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_editDictionaryViewModel.Name);
        }


        public override void Execute(object parameter)
        {
            IDictionaryDataService dictionaryDataService = new DictionaryDataService(new EntityFramework.AppDbContextFactory());
            var dic = new Dictionary
            {
                Name = _editDictionaryViewModel.Name,
                Id = _editDictionaryViewModel.Id
            };
            dictionaryDataService.Update(dic).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    MessageBox.Show($"{_editDictionaryViewModel.Name} has been successfully edited", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(task.Exception.Message, $"Error occured while editing {_editDictionaryViewModel.Name}", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }

        private void _editDictionaryViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_editDictionaryViewModel.Name))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
