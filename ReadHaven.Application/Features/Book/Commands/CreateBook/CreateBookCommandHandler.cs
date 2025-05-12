using AutoMapper;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;
using MediatR;

namespace ReadHaven.Application.Features.Books.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
{
    private readonly IAsyncRepository<Book> _bookRepository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IMapper mapper, IAsyncRepository<Book> bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var createBookCommandResponse = new CreateBookCommandResponse();

        // Assuming you have a validator for the CreateBookCommand
        var validator = new CreateBookCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            createBookCommandResponse.Success = false;
            createBookCommandResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createBookCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (createBookCommandResponse.Success)
        {
            var book = new Book
            {
                Title = request.Title,
                Genre = request.Genre,
                Price = request.Price,
                ImagePath = request.ImagePath
            };

            // Add the book to the repository
            book = await _bookRepository.AddAsync(book);
            createBookCommandResponse.Book = _mapper.Map<CreateBookDto>(book);
        }

        return createBookCommandResponse;
    }
}
