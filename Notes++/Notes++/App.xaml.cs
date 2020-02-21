using System;
using System.IO;
using Notesplusplus.Database;
using Xamarin.Forms;

namespace Notesplusplus
{
    public partial class App : Application
    {
        private static NotesDB database;

        public static NotesDB Database =>
            database ?? (database = new NotesDB(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Notesplusplus.db3")));

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
