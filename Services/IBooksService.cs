
using LibraryApi.Models;

public interface IBooksService
{
    IEnumerable<Book> GetBooks();  
    IEnumerable<Book> GetBooksByAuthor(int id);         // Henter alle bøker 
    Book? GetBookById(int id);               // Henter en bok basert på ID
    void AddBook(Book book);                // Legger til en bok
    void UpdateBook(int id, Book book);     // Oppdaterer en eksisterende bok
    void DeleteBook(int id);                // Sletter en bok basert på ID
}