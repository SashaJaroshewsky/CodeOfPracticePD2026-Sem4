
namespace DatabaseBasics.Entities
{
    internal class BookCopy
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public string Condition { get; set; } = "Good"; // стан: Good, Worn, etc.
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
