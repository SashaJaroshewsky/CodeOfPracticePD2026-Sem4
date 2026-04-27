using DatabaseBasics.DBContext;
using DatabaseBasics.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBasics
{
    // https://www.microsoft.com/uk-ua/sql-server/sql-server-downloads
    //База даних — це структуроване сховище даних у вигляді таблиць.Кожна таблиця — це набір рядків(записів) і стовпців(полів).
    internal class Program
    {
        static async Task Main(string[] args)
        {
            LibraryDbContext dbContext = new LibraryDbContext();
            Author author = new Author
            {
                FirstName = "J.K.",
                LastName = "Rowling",
                Bio = "British author, best known for the Harry Potter series."
            };

            Genre genre = new Genre
            {
                Name = "Fantasy"
            };

            Book book = new Book
            {
                Title = "Harry Potter and the Sorcerer's Stone",
                Author = author,
                Genres = new List<Genre> { genre },
            };

            dbContext.Authors.Add(author);
            dbContext.Genres.Add(genre);
            dbContext.Books.Add(book);

            await dbContext.SaveChangesAsync();

            Author author1 = await dbContext.Authors.FirstOrDefaultAsync(a => a.FirstName == "J.K." || a.LastName == "Rowling");
            Console.WriteLine($"Author: {author1.FirstName} {author1.LastName}");

        }
    }
}
