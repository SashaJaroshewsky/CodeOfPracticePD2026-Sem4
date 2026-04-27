
namespace DatabaseBasics.Entities
{
    internal class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
