using LibraryApi.Models;

namespace LibraryApi.Repository
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAllAuthors();
        Author? GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author auhtor);

    }
}