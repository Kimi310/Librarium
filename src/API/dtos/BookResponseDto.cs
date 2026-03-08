using Data.Models;

namespace API.dtos;

public class BookResponseDto
{
    public long BookId { get; set; }
    public string Title { get; set; } = null!;
    public string? Isbn { get; set; } = null!;
    public int PublicationYear { get; set; }
    

    public List<AuthorDto> Authors { get; set; } = new();

    public BookResponseDto DtoFromBook(Book book)
    {
        var authorDtos = new List<AuthorDto>();
        foreach (var author in book.Authors)
        {
            var authorDto = new AuthorDto().DtoFromAuthor(author);
            authorDtos.Add(authorDto);
        }

        return new BookResponseDto()
        {
            BookId = book.Id,
            Title = book.Title,
            Isbn = book.Isbn,
            PublicationYear = book.PublicationYear,
            Authors = authorDtos
        };
    }
}