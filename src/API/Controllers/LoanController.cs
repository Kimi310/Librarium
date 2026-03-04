using API.dtos;
using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api")]
public class LoanController(ILoanRepository loanRepository,IBookRepository bookRepository) : ControllerBase
{
    [HttpPost]
    [Route("loans")]
    public async Task<LoanResponseDto> CreateLoan([FromBody] NewLoanDto loanDto)
    {
        var book = await bookRepository.GetBookById(loanDto.BookId);
        if (book == null)
        {
            throw new Exception("Book not found");
        }
        else if (book.IsRetired)
        {
            throw new Exception("Book is retired");
        }
        
        var loan = new Loan()
        {
            BookId = loanDto.BookId,
            MemberId = loanDto.MemberId,
            LoanDate = loanDto.LoanDate,
            ReturnDate = loanDto.ReturnDate,
            Status =  loanDto.Status
        };

        var dbLoan = await loanRepository.NewLoan(loan);
        return new LoanResponseDto().FromLoan(dbLoan);
    }

    [HttpGet]
    [Route("loans/{memberId}")]
    public async Task<List<LoanResponseDto>> GetLoansByMemberId(int memberId)
    {
        var loans = await loanRepository.GetLoansForMember(memberId);
        return loans.Select(l => new LoanResponseDto().FromLoan(l)).ToList();
    }
}