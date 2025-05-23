

namespace ReadHaven.Application.Features.Books.Queries.GetBookDetails;
public class BookDetailsVm
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? ImagePath { get; set; } = null;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}