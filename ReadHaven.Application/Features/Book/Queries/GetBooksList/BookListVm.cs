namespace ReadHaven.Application.Features.Books.Queries;

public class BookListVm
{
    public Guid BookId { get; set; }  
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? ImagePath { get; set; } = null;
}
