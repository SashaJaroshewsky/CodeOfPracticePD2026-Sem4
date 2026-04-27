

namespace DatabaseBasics.Entities
{
    internal class Author
    {
        public int Id { get; set; }          // первинний ключ (PK)
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? Bio { get; set; }     // nullable = NULL в БД

        // Навігаційна властивість — зв'язок 1:Many з Book
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
