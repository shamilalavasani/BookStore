using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BookStore.Infrastructure.Persistence.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(b => b.Name)
             .IsRequired()
             .HasMaxLength(200);

        builder.Property(b => b.AuthorName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Description)
            .HasMaxLength(1000);

        builder.Property(b => b.ISBN)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(b => b.EditionVersion)
            .HasMaxLength(50);

        builder.Property(b => b.Price)
            .HasColumnType("decimal(18,2)");

        builder.Property(b => b.Category)
            .HasConversion<string>();
    }
}
