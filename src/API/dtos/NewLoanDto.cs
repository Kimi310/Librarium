namespace API.dtos;

public class NewLoanDto
{
    public long BookId { get; set; }

    public long MemberId { get; set; }

    public DateOnly LoanDate { get; set; }

    public DateOnly? ReturnDate { get; set; }
    
    public string Status { get; set; }
}