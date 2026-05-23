using BookStore.Application.DTOs;

namespace BookStore.Application.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookResponseDto>> GetAllAsync();

    Task<BookResponseDto?> GetByIsAsync(Guid id);
    Task<IEnumerable<BookResponseDto?>> GetAllByFilterAsync(
        string? searchTerm, string? SortBy, bool isDescending, int page, int pageSize);
    Task<BookResponseDto> AddAsync(BookRequestDto request);
    Task<BookResponseDto> UpdateAsync(Guid id, BookRequestDto request);
    Task DeleteAsync(Guid id);

}
