using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YourDictionaries.DbContexts;
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
        private const string CONNECTION_STRING = "Data Source=yourdic.db";
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            YourDictionariesDbContext dbContext = new YourDictionariesDbContext(options);
            dbContext.Database.Migrate();
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
