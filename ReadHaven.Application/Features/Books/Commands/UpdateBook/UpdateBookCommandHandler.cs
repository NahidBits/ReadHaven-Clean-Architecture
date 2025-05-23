using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Contracts.Services;
using ReadHaven.Application.Exceptions;
using ReadHaven.Domain.Entities;
using Microsoft.AspNetCore.Hosting;

namespace ReadHaven.Application.Features.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand,Unit>
{
    private readonly IAsyncRepository<Book> _bookRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly IWebHostEnvironment _env;

    public UpdateBookCommandHandler(
        IMapper mapper,
        IAsyncRepository<Book> bookRepository,
        IFileService fileService,
        IWebHostEnvironment env)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _fileService = fileService;
        _env = env;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateBookCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);

        var book = await _bookRepository.GetByIdAsync(request.BookId);
        if (book == null)
            throw new NotFoundException(nameof(Book), request.BookId);

        book.Title = request.Title;
        book.Genre = request.Genre;
        book.Price = request.Price;

        if (request.Image != null && request.Image.Length > 0)
        {
            if (!string.IsNullOrWhiteSpace(book.ImagePath))
            {
                var oldImagePath = Path.Combine(_env.WebRootPath, book.ImagePath.Replace("/", "\\"));
                if (File.Exists(oldImagePath))
                    File.Delete(oldImagePath);
            }

            var newImagePath = await _fileService.SaveFileAsync(request.Image, "uploads/books");
            book.ImagePath = newImagePath;
        }

        await _bookRepository.UpdateAsync(book);

        return Unit.Value;
    }
}
