using System;
using System.IO;
using truthordrink.Model;
using Xamarin.Forms;

namespace truthordrink
{
    public partial class App : Application
    {
        private static Database database;
        private static User authenticatedUser;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "truthordrinkfinal.db3"));
                }

                return database;
            }
        }

        public static void Authenticate(User user)
        {
            authenticatedUser = user;
        }

        public static void Unauthenticate()
        {
            authenticatedUser = null;
        }

        public static bool IsAuthenticated()
        {
            return authenticatedUser != null;
        }

        public static int GetAuthenticatedUserId()
        {
            return authenticatedUser.Id;
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
