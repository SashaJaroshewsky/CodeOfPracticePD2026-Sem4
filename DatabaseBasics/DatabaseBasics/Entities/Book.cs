
namespace DatabaseBasics.Entities
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Year { get; set; }
        public string? ISBN { get; set; }

        // Зовнішній ключ (FK) — зв'язок з Author
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        // Зв'язок 1:Many з BookCopy
        public ICollection<BookCopy> Copies { get; set; } = new List<BookCopy>();

        // Зв'язок Many:Many з Genre (через BookGenre)
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
