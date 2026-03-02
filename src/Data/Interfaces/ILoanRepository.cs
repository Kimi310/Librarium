using Data.Models;

namespace Data.Interfaces;

public interface ILoanRepository
{
    public Task<Loan> NewLoan(Loan loan);
    
    public Task<List<Loan>> GetLoansForMember(int memberId);
}