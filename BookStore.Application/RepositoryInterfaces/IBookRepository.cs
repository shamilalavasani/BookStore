using BookStore.Domain.Entities;

namespace BookStore.Application.RepositoryInterfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(Guid id);
    Task<Book> AddAsync(Book book);
    Task DeleteAsync(Book book);//for Hard Delete
    Task<Book> UpdateAsync(Book book);//For Update and Soft Delete
}
