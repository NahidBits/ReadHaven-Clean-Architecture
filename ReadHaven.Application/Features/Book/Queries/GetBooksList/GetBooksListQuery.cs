using MediatR;

namespace ReadHaven.Application.Features.Books.Queries;

public class GetBooksListQuery : IRequest<List<BookListVm>>
{
}
