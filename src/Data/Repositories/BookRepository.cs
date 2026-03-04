using Data.Data;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class BookRepository(AppDbContext context) : IBookRepository
{
    public async Task<List<Book>> GetAllBooks()
    {
        return await context.Books
            .Include(b => b.Authors)
            .ToListAsync();
    }

    public async Task<Book> GetBookById(long id)
    {
        var book = await context.Books.IgnoreQueryFilters()
            .FirstOrDefaultAsync(b => b.Id == id);
        
        return book;
    }
}