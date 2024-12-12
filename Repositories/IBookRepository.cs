using LibraryApi.Models;

namespace LibraryApi.Repository
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();
        IQueryable<Book> GetBooksByAuthor(int id);
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}