using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly LoanService _loanService;

        public LoansController(LoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public IActionResult GetAllLoans()
        {
            var loans = _loanService.GetAllLoans();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoanById(int id)
        {
            var loan = _loanService.GetLoanById(id);
            if (loan == null) return NotFound();

            return Ok(loan);
        }

        [HttpPost("borrow")]
        public IActionResult AddLoan(Loan loan)
        {
            try
            {
                _loanService.AddLoan(loan);
                return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, loan);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("return/{id}")]
        public IActionResult ReturnLoan(int id)
        {
            try
            {
                _loanService.ReturnLoan(id);
                return Ok(new { message = "Book returned successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoan(int id)
        {
            _loanService.DeleteLoan(id);
            return NoContent();
        }
    }
}
