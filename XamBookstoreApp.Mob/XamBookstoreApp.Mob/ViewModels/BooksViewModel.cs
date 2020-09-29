using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamBookstoreApp.Mob.Models;
using XamBookstoreApp.Mob.Services;
using XamBookstoreApp.Mob.Views;

namespace XamBookstoreApp.Mob.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        private Book _selectedBook;

        public ObservableCollection<Book> Books { get; }
        public Command LoadBooksCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Book> ItemTapped { get; }

        public BooksViewModel()
        {
            Title = "Browse Books";
            Books = new ObservableCollection<Book>();
            LoadBooksCommand = new Command(async () => await ExecuteLoadBooksCommand());

            ItemTapped = new Command<Book>(OnBookSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadBooksCommand()
        {
            IsBusy = true;

            try
            {
                Books.Clear();

                var bookResult = await BookstoreService.Instance.GetBook();

                if (bookResult.DidSucceed)
                {
                    var books = bookResult.ResponseObject as List<Book>;
                    foreach (var book in books)
                    {
                        Books.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBook = null;
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                SetProperty(ref _selectedBook, value);
                OnBookSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewBookPage));
        }

        async void OnBookSelected(Book book)
        {
            if (book == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?{nameof(BookDetailViewModel.Id)}={book.Id}");
        }
    }
}