using Data.Models;

namespace Data.Interfaces;

public interface IMemberRepository
{
    public Task<List<Member>> GetMembers();
}