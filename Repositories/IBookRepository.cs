using LibraryApi.Models;

namespace LibraryApi.Repository
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}