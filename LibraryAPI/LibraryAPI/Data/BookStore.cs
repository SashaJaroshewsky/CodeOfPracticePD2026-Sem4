using LibraryAPI.Models;

namespace LibraryAPI.Data
{
    public class BookStore
    {
        private readonly List<Book> _books = new()
        {
            new Book { Id = 1, Title = "Кобзар",              Author = "Тарас Шевченко",          Year = 1840 },
            new Book { Id = 2, Title = "Тіні забутих предків", Author = "Михайло Коцюбинський",    Year = 1911 },
            new Book { Id = 3, Title = "Місто",               Author = "Валер'ян Підмогильний",   Year = 1928 },
        };

        private int _nextId = 4;

        // Повертає посилання на внутрішній список.
        // BookService читає і змінює його через ці методи — не напряму.
        public List<Book> Books => _books;

        public int NextId() => _nextId++;
    }
}
