using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        Book Create(Book book);
        Book? Update(int id, Book book);
        bool Delete(int id);
    }
}
