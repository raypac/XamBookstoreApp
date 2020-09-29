using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamBookstoreApp.Mob.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamBookstoreApp.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}