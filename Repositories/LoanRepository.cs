using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _context;

        public LoanRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return _context.Loans.Include(l => l.Book).ThenInclude(b => b.Author).ToList();
        }

        public Loan GetLoanById(int id)
        {
            return _context.Loans.Include(l => l.Book).FirstOrDefault(l => l.Id == id);
        }

        public void AddLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void UpdateLoan(Loan loan)
        {
            _context.Loans.Update(loan);
            _context.SaveChanges();
        }

        public void DeleteLoan(int id)
        {
            var loan = GetLoanById(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }
        }
    }
}
