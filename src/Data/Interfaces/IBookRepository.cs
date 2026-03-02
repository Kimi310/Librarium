using Data.Models;

namespace Data.Interfaces;

public interface IBookRepository
{
    public Task<List<Book>> GetAllBooks();
}