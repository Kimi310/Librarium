using API.dtos;
using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api")]
public class LoanController(ILoanRepository loanRepository) : ControllerBase
{
    [HttpPost]
    [Route("loans")]
    public async Task<Loan> CreateLoan([FromBody] NewLoanDto loanDto)
    {
        var loan = new Loan()
        {
            BookId = loanDto.BookId,
            MemberId = loanDto.MemberId,
            LoanDate = loanDto.LoanDate,
            ReturnDate = loanDto.ReturnDate
        };
        return await loanRepository.NewLoan(loan);
    }

    [HttpGet]
    [Route("loans/{memberId}")]
    public async Task<List<Loan>> GetLoansByMemberId(int memberId)
    {
        return await loanRepository.GetLoansForMember(memberId);
    }
}