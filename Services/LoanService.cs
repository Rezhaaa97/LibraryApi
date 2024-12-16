using LibraryApi.Models;
using LibraryApi.Repositories;

namespace LibraryApi.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return _loanRepository.GetAllLoans();
        }

        public Loan GetLoanById(int id)
        {
            return _loanRepository.GetLoanById(id);
        }

        public void AddLoan(Loan loan)
        {
            // Validering før lån legges til
            if (loan.BookId == 0)
                throw new ArgumentException("BookId is required.");
            if (loan.LoanDate > DateTime.Now)
                throw new ArgumentException("LoanDate cannot be in the future.");

            _loanRepository.AddLoan(loan);
        }

        public void ReturnLoan(int id)
        {
            var loan = _loanRepository.GetLoanById(id);
            if (loan == null || loan.ReturnDate != null)
                throw new ArgumentException("Loan not found or already returned.");

            loan.ReturnDate = DateTime.Now;
            _loanRepository.UpdateLoan(loan);
        }

        public void DeleteLoan(int id)
        {
            _loanRepository.DeleteLoan(id);
        }
    }
}
