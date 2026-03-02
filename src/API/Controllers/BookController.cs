using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api")]
public class BookController(IBookRepository repository) : ControllerBase
{
    [HttpGet]
    [Route("books")]
    public async Task<List<Book>> GetBooks()
    {
        return await repository.GetAllBooks();
    }
}