using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImagesGalery
{
    public partial class App : Application
    {

        public const string DATABASE_NAME = "images.db";
        public static DBContext.ImagesRepository database;
        public static DBContext.ImagesRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBContext.ImagesRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
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
