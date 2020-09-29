using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamBookstoreApp.Mob.Services;
using XamBookstoreApp.Mob.Views;

namespace XamBookstoreApp.Mob
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
