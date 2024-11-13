
using LibraryApi.Models;

public class BooksService : IBooksService
{
    public static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "Georg Orvell", Year = 1949 },
            new Book { Id = 2, Title = "To Kill", Author = "Harpe Lee", Year = 1960 }
        };

    public IEnumerable<Book> GetBooks() => books;

    public Book? GetBookById(int id) => books.FirstOrDefault(b => b.Id == id) ?? new Book();

    public void AddBook(Book book)
    {
        book.Id = books.Max(b => b.Id) + 1; // Genererer ny Id basert på maks id fra books
        books.Add(book);
    }

    public void UpdateBook(int id, Book updatedBook)
    {
        var book = GetBookById(id);
        if (book == null) return;

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.Year = updatedBook.Year;
    }

    public void DeleteBook(int id)
    {
        var book = GetBookById(id);
        if(book != null) books.Remove(book);
    }
}