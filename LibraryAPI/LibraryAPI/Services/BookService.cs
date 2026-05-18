using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        // BookStore приходить через Dependency Injection — так само як сам
        // BookService приходив у контролер.
        private readonly BookStore _store;

        public BookService(BookStore store)
        {
            _store = store;
        }

        public IEnumerable<Book> GetAll() => _store.Books;

        public Book? GetById(int id) =>
            _store.Books.FirstOrDefault(b => b.Id == id);

        public Book Create(Book book)
        {
            book.Id = _store.NextId();
            _store.Books.Add(book);
            return book;
        }

        public Book? Update(int id, Book book)
        {
            var existing = GetById(id);
            if (existing is null) return null;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Year = book.Year;
            existing.ISBN = book.ISBN;
            existing.IsAvailable = book.IsAvailable;
            return existing;
        }

        public bool Delete(int id)
        {
            var book = GetById(id);
            if (book is null) return false;
            _store.Books.Remove(book);
            return true;
        }
    }
}
