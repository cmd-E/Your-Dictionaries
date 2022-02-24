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
    public class CreateDictionaryCommand : BaseCommand
    {
        private readonly CreateDictionaryViewModel _createDictionaryViewModel;

        public CreateDictionaryCommand(CreateDictionaryViewModel createDictionaryViewModel)
        {
            _createDictionaryViewModel = createDictionaryViewModel;
        }

        public override void Execute(object parameter)
        {
            IDictionaryDataService dictionaryDataService = new DictionaryDataService(new EntityFramework.AppDbContextFactory());
            dictionaryDataService.Create(new Dictionary
            {
                Name = _createDictionaryViewModel.Name
            }).ContinueWith(task => 
            {
                if (task.Exception == null)
                {
                    MessageBox.Show($"Dictionary {_createDictionaryViewModel.Name} created successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"Error occured while creating dictionary {_createDictionaryViewModel.Name}: {task.Exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
