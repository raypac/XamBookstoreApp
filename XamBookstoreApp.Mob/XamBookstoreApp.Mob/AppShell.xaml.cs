using System;
using System.Collections.Generic;
using XamBookstoreApp.Mob.ViewModels;
using XamBookstoreApp.Mob.Views;
using Xamarin.Forms;

namespace XamBookstoreApp.Mob
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookDetailPage), typeof(BookDetailPage));
            Routing.RegisterRoute(nameof(NewBookPage), typeof(NewBookPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
