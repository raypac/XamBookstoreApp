using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using XamBookstoreApp.Mob.Models;
using Xamarin.Forms;
using XamBookstoreApp.Mob.Utilities;
using XamBookstoreApp.Mob.Services;

namespace XamBookstoreApp.Mob.ViewModels
{
    public class NewBookViewModel : BaseViewModel
    {
        private string name;
        private double price;
        private string category;
        private string author;
        private List<string> categoryList;

        public NewBookViewModel()
        {
            Title = "New Book";

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            CategoryList = StaticDefinition.CategoryList;
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && price != 0d
                && !String.IsNullOrWhiteSpace(category)
                && !String.IsNullOrWhiteSpace(author);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public double Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public string Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        public List<string> CategoryList
        {
            get => categoryList;
            set => SetProperty(ref categoryList, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Book book = new Book()
            {
                Id = string.Empty,
                Name = Name,
                Price = Price,
                Category = Category,
                Author = Author
            };

            await BookstoreService.Instance.SaveBook(book);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
