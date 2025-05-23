using MediatR;

namespace ReadHaven.Application.Features.Books.Commands.DeleteBook;

public class DeleteBookCommand : IRequest<Unit>
{
    public Guid BookId { get; set; }
}
