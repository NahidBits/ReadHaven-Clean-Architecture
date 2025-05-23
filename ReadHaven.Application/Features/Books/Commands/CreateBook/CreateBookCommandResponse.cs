using ReadHaven.Application.Responses;

namespace ReadHaven.Application.Features.Books.Commands.CreateBook;

public class CreateBookCommandResponse : BaseResponse
{
    public CreateBookCommandResponse() : base()
    {
    }

    // Changed to 'Book' instead of 'Category'
    public CreateBookDto Book { get; set; } = default!;
}
