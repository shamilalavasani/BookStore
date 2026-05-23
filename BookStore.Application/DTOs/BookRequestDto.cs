using BookStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace BookStore.Application.DTOs;

public class BookRequestDto
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string AuthorName { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    [Range(1000, 2100)]
    public int Year { get; set; }
    [Range(0.01, 10000)]
    public decimal Price { get; set; }
    [Required]
    [MaxLength(20)]
    public string ISBN { get; set; } = string.Empty;
    [MaxLength(50)]
    public string EditionVersion { get; set; } = string.Empty;
    public BookCategory Category { get; set; }

}
