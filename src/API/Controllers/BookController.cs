using API.dtos;
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
    public async Task<List<BookResponseDto>> GetBooks()
    {
        var booksWithAuthors = await repository.GetAllBooks();
        var response = new List<BookResponseDto>();
        foreach (var ba in booksWithAuthors)
        {
            var book = new BookResponseDto().DtoFromBook(ba);
            response.Add(book);
        }
        return response;
    }
}