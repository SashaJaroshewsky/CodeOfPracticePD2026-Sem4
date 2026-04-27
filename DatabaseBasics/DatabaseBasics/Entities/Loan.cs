
namespace DatabaseBasics.Entities
{
    internal class Loan
    {
        public int Id { get; set; }
        public int BookCopyId { get; set; }
        public BookCopy BookCopy { get; set; } = null!;
        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public DateTime LoanedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnedAt { get; set; }  // null = ще не повернуто
    }
}
