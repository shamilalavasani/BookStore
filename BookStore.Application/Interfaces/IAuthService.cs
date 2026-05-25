using BookStore.Application.DTOs;

namespace BookStore.Application.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto request);
    Task<string> LoginAsync(LoginDto request);
}
