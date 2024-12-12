using LibraryApi.Models;
using LibraryApi.Repository;

namespace LibraryApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAllAuthors() => _authorRepository.GetAllAuthors();
    
        public Author? GetAuthorById(int id) => _authorRepository.GetAuthorById(id);

        public void AddAuthor(Author author) => _authorRepository.AddAuthor(author);
            
        public void UpdateAuthor(Author author) => _authorRepository.UpdateAuthor(author);

        public void DeleteAuthor(int id)
        {
            var author = GetAuthorById(id);
            if (author != null)
            {
                _authorRepository.DeleteAuthor(author);
            }
        } 





    }
}