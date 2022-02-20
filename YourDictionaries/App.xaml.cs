using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YourDictionaries.Services;
using YourDictionaries.State;
using YourDictionaries.ViewModels;

namespace YourDictionaries
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Mapper.InitMapper();
            NavigationState navigationState = new NavigationState();
            navigationState.CurrentViewModel = new DictionaryBrowseViewModel(navigationState);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationState)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
