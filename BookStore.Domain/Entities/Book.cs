using BookStore.Domain.Enums;

namespace BookStore.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string AuthorName { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public int Year { get; private set; }
    public decimal Price { get; private set; }
    public string ISBN { get; private set; } = string.Empty;
    public string EditionVersion { get; private set; } = string.Empty;
    public BookCategory Category { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    private Book()
    {
    }

    public static Book Create(
        string name, string authorName,
        string description, int year,
        decimal price, string isbn, string editionVersion, BookCategory category)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Name = name,
            AuthorName = authorName,
            Description = description,
            Year = year,
            Price = price,
            ISBN = isbn,
            EditionVersion = editionVersion,
            Category = category



        };
    }
    public void Update(string name, string authorName,
        string description, int year,
        decimal price, string isbn, string editionVersion, BookCategory category)
    {
        Name = name;
        AuthorName = authorName;
        Description = description;
        Year = year; Price = price;
        ISBN = isbn;
        EditionVersion = editionVersion;
        Category = category;

    }


    public void Delete()
    {
        IsDeleted = true;
    }

}
