using LibraryApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _booksService.GetBooks(); 
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _booksService.GetBookById(id);
            if (book == null)
            {
                Log.Information("Book er null!");
                NotFound();
            }
            return Ok(book);
        }

        [HttpGet("author/{authorId}")]
        public ActionResult<IEnumerable<Book>> GetBooksByAuthor(int authorId)
        {
            return Ok(_booksService.GetBooksByAuthor(authorId).ToList());
        }

        
        [HttpPost]
        public ActionResult<Book> CreateBook(Book newBook)
        {
            _booksService.AddBook(newBook);
            return CreatedAtAction(nameof(GetBook), new {id = newBook.Id}, newBook); 
        }

        // PUT: api/books/{id}

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book updatedBook)
        {
            var existingBook = _booksService.GetBookById(id);
            if(existingBook == null)
            {
                return NotFound();
            }
            _booksService.UpdateBook(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            _booksService.DeleteBook(id);
            return NoContent();
        }
    }
}
