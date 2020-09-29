using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamBookstoreApp.Mob.Models;
using XamBookstoreApp.Mob.Views;
using XamBookstoreApp.Mob.ViewModels;

namespace XamBookstoreApp.Mob.Views
{
    public partial class BooksPage : ContentPage
    {
        BooksViewModel _viewModel;

        public BooksPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new BooksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}