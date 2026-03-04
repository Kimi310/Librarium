using Data.Data;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class LoanRepository(AppDbContext context) : ILoanRepository
{
    public async Task<Loan> NewLoan(Loan loan)
    {
        context.Loans.Add(loan);
        await context.SaveChangesAsync();
        return await context.Loans.FirstOrDefaultAsync(l => l.Id == loan.Id);
    }

    public async Task<List<Loan>> GetLoansForMember(int memberId)
    {
        return await context.Loans.Where(l => l.MemberId == memberId).Include(l => l.Book).IgnoreQueryFilters()
            .ToListAsync();
    }
}