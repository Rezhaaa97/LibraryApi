using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public IQueryable<Book> GetAllBooks() => _context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Loans);


        public Book GetBookById(int id) => _context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Loans)
                    .FirstOrDefault(b => b.Id == id) ?? new Book();


        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}