
using System.IO.Compression;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryApi.Data
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options){}

        public DbSet<Book> Books {get; set;} 
        public DbSet<Author> Authors {get; set;} 
        public DbSet<Loan> Loans {get; set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //  base.OnModelCreating(modelBuilder);   
            // Relasjon en forfatter kan skrive mange bøker
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            // Relasjon en Bok kan ha mange lån

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Loans)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.BookId);


            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "George Orwell" },
                new Author { Id = 2, Name = "Harper Lee" },
                new Author { Id = 3, Name = "Aldous Huxley" },
                new Author { Id = 4, Name = "J.K. Rowling" },
                new Author { Id = 5, Name = "Ronny" },
                new Author { Id = 6, Name = "Daniel" },
                new Author { Id = 7, Name = "Linda" }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Year = 1949, AuthorId = 1 },
                new Book { Id = 2, Title = "Animal Farm", Year = 1945, AuthorId = 1 },
                new Book { Id = 3, Title = "To Kill a Mockingbird", Year = 1960, AuthorId = 2 },
                new Book { Id = 4, Title = "Brave New World", Year = 1932, AuthorId = 3 },
                new Book { Id = 5, Title = "Harry Potter and the Philosopher's Stone", Year = 1997, AuthorId = 4 }
            );

            // Seed Loans
            modelBuilder.Entity<Loan>().HasData(
                new Loan { Id = 1, BookId = 1, LoanDate = new DateTime(2024, 12, 2), ReturnDate = null },
                new Loan { Id = 2, BookId = 2, LoanDate = new DateTime(2024, 12, 2), ReturnDate = new DateTime(2024, 12, 12) },
                new Loan { Id = 3, BookId = 4, LoanDate = new DateTime(2024, 12, 2), ReturnDate = null }
            );

        }

    }
    
}