using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YourDictionaries.Models;

namespace YourDictionaries
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //TODO: Here is some code that could be easily forgoten
            Dictionary myDictionary = new Dictionary("Test");
            myDictionary.AddPhraseEntry(new PhraseEntry(
                "Hello world",
                "Greeting",
                "/lalala/",
                "Привет мир"
                ));
            IEnumerable<PhraseEntry> entries = myDictionary.GetAllPhraseEntries();
            base.OnStartup(e);
        }
    }
}
