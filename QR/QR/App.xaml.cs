using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QR;
using QR.Data;
using System.IO;
namespace QR
{
     
    public partial class App : Application
    {
        static SQLHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static SQLHelper sqLiteDb
        {
            get
            {
                if (db == null)
                    db = new SQLHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Escanner.db3"));

                return db;
            }
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
