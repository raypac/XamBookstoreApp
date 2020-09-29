using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamBookstoreApp.Mob.Models;
using XamBookstoreApp.Mob.ViewModels;

namespace XamBookstoreApp.Mob.Views
{
    public partial class NewBookPage : ContentPage
    {
        public Book Book { get; set; }

        public NewBookPage()
        {
            InitializeComponent();
            BindingContext = new NewBookViewModel();
        }
    }
}