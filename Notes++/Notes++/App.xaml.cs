using System;
using System.IO;
using Notes__.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes__
{
    public partial class App : Application
    {
        private static NotesDB database;

        public static NotesDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new NotesDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notesplusplus.db3"));
                }

                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
