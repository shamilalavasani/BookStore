using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Application.RepositoryInterfaces;
using BookStore.Domain.Entities;

namespace BookStore.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<BookResponseDto> AddAsync(BookRequestDto request)
    {
        var book = Book.Create(
            request.Name,
            request.AuthorName,
            request.Description,
            request.Year,
            request.Price,
            request.ISBN,
            request.EditionVersion,
            request.Category);

        await _bookRepository.AddAsync(book);
        return MapToDto(book);

    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            throw new Exception("Book not found");
        book.Delete();
        await _bookRepository.UpdateAsync(book);

    }

    public async Task<IEnumerable<BookResponseDto>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return books.Select(MapToDto);

    }

    public async Task<IEnumerable<BookResponseDto?>> GetAllByFilterAsync(string? searchTerm, string? SortBy, bool isDescending, int page, int pageSize)
    {
        var books = await _bookRepository.GetAllAsync();
        //Search
        if (!string.IsNullOrEmpty(searchTerm))
            books = books.Where(b =>
            b.Name.Contains(searchTerm) ||
            b.AuthorName.Contains(searchTerm));
        //Sort
        books = SortBy switch
        {
            "name" => isDescending ? books.OrderByDescending(b => b.Name) : books.OrderBy(b => b.Name),
            "year" => isDescending ? books.OrderByDescending(b => b.Year) : books.OrderBy(b => b.Year),
            "price" => isDescending ? books.OrderByDescending(b => b.Price) : books.OrderBy(b => b.Price),
            _ => books
        };
        //pagination
        books = books.Skip((page - 1) * pageSize).Take(pageSize);
        return books.Select(b => MapToDto(b));
    }

    public async Task<BookResponseDto?> GetByIsAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            throw new Exception("Book not found");
        return MapToDto(book);
    }

    public async Task<BookResponseDto> UpdateAsync(Guid id, BookRequestDto request)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            throw new Exception("Book not found");
        book.Update(
          request.Name,
           request.AuthorName,
           request.Description,
           request.Year,
           request.Price,
           request.ISBN,
           request.EditionVersion,
           request.Category
           );
        await _bookRepository.UpdateAsync(book);
        return MapToDto(book);
    }
    private static BookResponseDto MapToDto(Book book)
    {
        return new BookResponseDto
        {
            Id = book.Id,
            Name = book.Name,
            AuthorName = book.AuthorName,
            Description = book.Description,
            Year = book.Year,
            Price = book.Price,
            ISBN = book.ISBN,
            EditionVersion = book.EditionVersion,
            Category = book.Category

        };
    }
}
