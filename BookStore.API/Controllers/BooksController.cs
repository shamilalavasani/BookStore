using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var book = await _bookService.GetByIsAsync(id);
        return Ok(book);
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(BookRequestDto request)
    {
        var book = await _bookService.AddAsync(request);
        return Ok(book);

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, BookRequestDto request)
    {
        var book = await _bookService.UpdateAsync(id, request);
        return Ok(book);

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _bookService.DeleteAsync(id);
        return NoContent();

    }
}