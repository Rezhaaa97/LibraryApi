
using System.IO.Compression;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryApi.Data
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> optione) : base(optione){}

        public DbSet<Book> Books {get; set;} 
        public DbSet<Author> Authors {get; set;} 
        public DbSet<Loan> Loans {get; set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }

    }
    
}