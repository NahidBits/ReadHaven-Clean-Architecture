using MediatR;

namespace ReadHaven.Application.Features.Books.Queries.GetBookDetails;

public class GetBookDetailsQuery : IRequest<BookDetailsVm>
{
    public Guid BookId { get; set; }
}
