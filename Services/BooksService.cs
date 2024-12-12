
using LibraryApi.Models;
using LibraryApi.Repository;
using Serilog;

public class BooksService : IBooksService
{
    private readonly IBookRepository _bookRepository;

    public BooksService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public IEnumerable<Book> GetBooks() => _bookRepository.GetAllBooks().ToList();

    public IEnumerable<Book> GetBooksByAuthor(int id) => _bookRepository.GetBooksByAuthor(id);


    public Book? GetBookById(int id) => _bookRepository.GetBookById(id);

    public void AddBook(Book book)
    {
        if(book == null) return;

        _bookRepository.AddBook(book);
        Log.Information($"Book {book.Title} added");
        
    }

    public void UpdateBook(int id, Book updatedBook)
    {
        var book = GetBookById(id);
        if (book == null) return;

        _bookRepository.UpdateBook(book);
        Log.Information($"The Book {book.Title} is updated");
    }

    public void DeleteBook(int id)
    {
        _bookRepository.DeleteBook(id);
    }
}