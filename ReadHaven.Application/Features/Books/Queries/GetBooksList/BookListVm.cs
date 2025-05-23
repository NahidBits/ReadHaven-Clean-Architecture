namespace ReadHaven.Application.Features.Books.Queries.GetBooksList;

public class BookListVm
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? ImagePath { get; set; } = null;
}
