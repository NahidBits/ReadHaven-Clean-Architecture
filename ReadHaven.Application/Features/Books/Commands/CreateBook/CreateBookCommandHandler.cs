using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Contracts.Services;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Books.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
{
    private readonly IAsyncRepository<Book> _bookRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public CreateBookCommandHandler(
        IMapper mapper,
        IAsyncRepository<Book> bookRepository,
        IFileService fileService)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _fileService = fileService;
    }

    public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateBookCommandResponse();

        var validator = new CreateBookCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        string? imagePath = null;

        if (request.Image != null)
        {
            imagePath = await _fileService.SaveFileAsync(request.Image, "uploads/books");
        }

        var book = new Book
        {
            Title = request.Title,
            Genre = request.Genre,
            Price = request.Price,
            ImagePath = imagePath
        };

        book = await _bookRepository.AddAsync(book);
        response.Book = _mapper.Map<CreateBookDto>(book);

        return response;
    }
}
