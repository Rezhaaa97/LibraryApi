using LibraryApi.Models;

namespace LibraryApi.Repositories
{
    public interface ILoanRepository
    {
        IEnumerable<Loan> GetAllLoans();
        Loan GetLoanById(int id);
        void AddLoan(Loan loan);
        void UpdateLoan(Loan loan);
        void DeleteLoan(int id);
    }
}
