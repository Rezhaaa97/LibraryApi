using LibraryApi.Data;
using LibraryApi.Models;

namespace LibraryApi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public IQueryable<Author> GetAllAuthors() => _context.Authors;

        public Author? GetAuthorById(int id) => _context.Authors.FirstOrDefault(a => a.Id == id);


        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();

        }
    }

}