using System;
using System.Diagnostics;
using System.Threading.Tasks;
using XamBookstoreApp.Mob.Models;
using Xamarin.Forms;
using System.Collections.Generic;
using XamBookstoreApp.Mob.Services;
using XamBookstoreApp.Mob.Utilities;

namespace XamBookstoreApp.Mob.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class BookDetailViewModel : BaseViewModel
    {
        private string id;
        private string name;
        private double price;
        private string category;
        private string author;
        private List<string> categoryList;

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                SetProperty(ref id, value);

                Task.Run(async () =>
                {
                    await LoadBook(value);
                });
            }
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

        public Command UpdateCommand { get; }
        public Command DeleteCommand { get; }
        public Command CancelCommand { get; }

        public async Task LoadBook(string value)
        {
            try
            {
                var bookResult = await BookstoreService.Instance.GetBook(value);

                if (bookResult.DidSucceed)
                {
                    var book = bookResult.ResponseObject as Book;

                    if (book != null)
                    {
                        Name = book.Name;
                        Price = book.Price;
                        Category = book.Category;
                        Author = book.Author;
                    }
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public BookDetailViewModel()
        {
            Title = "Book Detail";

            CategoryList = StaticDefinition.CategoryList;

            UpdateCommand = new Command(OnUpdate);
            DeleteCommand = new Command(OnDelete);
            CancelCommand = new Command(OnCancel);
        }

        private bool ValidateUpdate()
        {
            return !String.IsNullOrWhiteSpace(name)
                && price != 0d
                && !String.IsNullOrWhiteSpace(category)
                && !String.IsNullOrWhiteSpace(author);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnUpdate()
        {
            if (!ValidateUpdate())
                return;

            Book book = new Book()
            {
                Id = Id,
                Name = Name,
                Price = Price,
                Category = Category,
                Author = Author
            };

            await BookstoreService.Instance.UpdateBook(book);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDelete()
        {
            await BookstoreService.Instance.DeleteBook(Id);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
