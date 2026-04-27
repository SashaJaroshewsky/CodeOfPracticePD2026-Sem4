using DatabaseBasics.Entities;
using Microsoft.EntityFrameworkCore;
namespace DatabaseBasics.DBContext
{
    internal class LibraryDbContext: DbContext
    {
        // Кожен DbSet<T> = окрема таблиця в БД
        public DbSet<Author> Authors => Set<Author>(); // таблиця Authors // Set<T>() — базовий метод для отримання DbSet<T>
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<BookCopy> BookCopies => Set<BookCopy>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Loan> Loans => Set<Loan>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    $"Server=DESKTOP-M3Q4HRF;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
                );
            }
        }

        // OnModelCreating — тут налаштовуємо зв'язки і обмеження
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ----- Author -----
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(a => a.LastName).IsRequired().HasMaxLength(100);
            });

            // ----- Book -----
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(300);
                entity.Property(b => b.ISBN).HasMaxLength(20);

                // Зв'язок Book -> Author (Many:1)
                // Якщо автора видалити — книги залишаться (Restrict)
                entity.HasOne(b => b.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(b => b.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ----- Book <-> Genre (Many:Many) -----
            // EF Core 5+ сам створює проміжну таблицю BookGenre
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books);


            // ----- BookCopy -----
            // Зв'язок BookCopy -> Book (Many:1)
            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.HasOne(bc => bc.Book)
                      .WithMany(b => b.Copies)
                      .HasForeignKey(bc => bc.BookId)
                      .OnDelete(DeleteBehavior.Cascade); // видалення книги = видалення примірників
            });

            // ----- Loan -----
            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasOne(l => l.BookCopy)
                      .WithMany(bc => bc.Loans)
                      .HasForeignKey(l => l.BookCopyId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Member)
                      .WithMany(m => m.Loans)
                      .HasForeignKey(l => l.MemberId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        // Для роботи з міграціями використовуються команди в терміналі:
        // dotnet ef migrations add InitialCreate
        // dotnet ef database update
        // Ці команди створять міграцію (клас з кодом для створення таблиць) і застосують її до бази даних.

        // зручніше використовувати Package Manager Console в Visual Studio:
        // Add-Migration InitialCreate
        // Update-Database
        // Drop-Database
        // Update-Database -Migration: InitialCreate
        // Remove-Migration
        // Міграції — це спосіб керувати змінами в схемі бази даних. Вони дозволяють створювати, змінювати і видаляти таблиці та інші об'єкти БД через код.
    }
}
