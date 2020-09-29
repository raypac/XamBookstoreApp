using System.ComponentModel;
using Xamarin.Forms;
using XamBookstoreApp.Mob.ViewModels;

namespace XamBookstoreApp.Mob.Views
{
    public partial class BookDetailPage : ContentPage
    {
        public BookDetailPage()
        {
            InitializeComponent();
            BindingContext = new BookDetailViewModel();
        }
    }
}