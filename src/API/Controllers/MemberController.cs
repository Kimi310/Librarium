using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api")]
[ApiController]
public class MemberController(IMemberRepository repository) : ControllerBase
{
    [HttpGet]
    [Route("members")]
    public async Task<List<Member>> GetMembers()
    {
        return await repository.GetMembers();
    }
}