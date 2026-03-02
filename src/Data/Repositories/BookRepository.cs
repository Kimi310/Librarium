using Data.Data;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class BookRepository(AppDbContext context) : IBookRepository
{
    public async Task<List<Book>> GetAllBooks()
    {
        return await context.Books.ToListAsync();
    }
}