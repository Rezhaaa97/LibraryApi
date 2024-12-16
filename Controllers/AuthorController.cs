using System.Security.Principal;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAllAuthors() => Ok(_authorService.GetAllAuthors());

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if(author == null)
               return NotFound();
        
            return Ok(author);
        }
        
        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            _authorService.AddAuthor(author);
            return CreatedAtAction(nameof(GetAuthorById), new {id = author.Id}, author);        
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
                return BadRequest();
            
            var existingAuthor = _authorService.GetAuthorById(id);
            if(existingAuthor == null)
               return NotFound();

            _authorService.UpdateAuthor(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null) return NotFound();

            _authorService.DeleteAuthor(id);
            return NoContent();
        }

    }
    
}