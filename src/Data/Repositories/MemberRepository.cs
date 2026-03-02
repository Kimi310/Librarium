using Data.Data;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class MemberRepository(AppDbContext context) : IMemberRepository
{
    public async Task<List<Member>> GetMembers()
    {
        return await context.Members.ToListAsync();
    }
}