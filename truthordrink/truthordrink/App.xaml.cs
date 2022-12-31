using System;
using Xamarin.Forms;

namespace truthordrink
{
    public partial class App : Application
    {
        public static string Databaselocation = String.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

        }

        public App(string databaseLocation) : this()
        {
            if (Databaselocation == null)
            {
                throw new ArgumentNullException(nameof(Databaselocation));
            }
            Databaselocation = databaseLocation;
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
