using Data.Models;

namespace API.dtos;

public class LoanResponseDto
{
    public long Id { get; set; }

    public long BookId { get; set; }

    public long MemberId { get; set; }

    public DateOnly LoanDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string Status { get; set; } = null!;


    public LoanResponseDto FromLoan(Loan loan)
    {
        return new LoanResponseDto()
        {
            Id = loan.Id,
            BookId = loan.BookId,
            MemberId = loan.MemberId,
            LoanDate = loan.LoanDate,
            ReturnDate = loan.ReturnDate,
            Status = loan.Status,
        };
    }
}