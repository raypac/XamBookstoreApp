using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using XamBookstoreApp.Api.Models;

namespace XamBookstoreApp.Api.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> Get() =>
            _books.Find(book => true).ToList();

        public Book Get(string id) =>
            _books.Find(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book book) =>
            _books.ReplaceOne(book => book.Id == id, book);

        public void Remove(Book _book) =>
            _books.DeleteOne(book => book.Id == _book.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }

}
