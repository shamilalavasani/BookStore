using BookStore.Domain.Enums;

namespace BookStore.Application.DTOs;

public class BookResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string EditionVersion { get; set; } = string.Empty;
    public BookCategory Category { get; set; }

}
