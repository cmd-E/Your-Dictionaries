using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YourDictionaries.Models;
using YourDictionaries.Services;
using YourDictionaries.Stores;
using YourDictionaries.ViewModels;

namespace YourDictionaries
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateDictionaryBrowseViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private AddPhraseViewModel CreateAddPhraseViewModel()
        {
            return new AddPhraseViewModel(new NavigationService(_navigationStore, CreateDictionaryBrowseViewModel));
        }

        private DictionaryBrowseViewModel CreateDictionaryBrowseViewModel()
        {
            return new DictionaryBrowseViewModel(new NavigationService(_navigationStore, CreateAddPhraseViewModel));
        }
    }
}
