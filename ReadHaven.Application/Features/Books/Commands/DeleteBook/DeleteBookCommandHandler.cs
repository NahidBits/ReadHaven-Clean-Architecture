using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Exceptions;
using ReadHaven.Domain.Entities;
using Microsoft.AspNetCore.Hosting;

namespace ReadHaven.Application.Features.Books.Commands.DeleteBook;

public class DeleteCartItemCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IAsyncRepository<Book> _bookRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public DeleteCartItemCommandHandler(
        IMapper mapper,
        IAsyncRepository<Book> bookRepository,
        IWebHostEnvironment env)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _env = env;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var bookToDelete = await _bookRepository.GetByIdAsync(request.BookId);

        if (bookToDelete == null)
        {
            throw new NotFoundException(nameof(Book), request.BookId);
        }

        // Delete the associated image file if it exists
        if (!string.IsNullOrWhiteSpace(bookToDelete.ImagePath))
        {
            var imagePath = Path.Combine(_env.WebRootPath, bookToDelete.ImagePath.Replace("/", "\\"));
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        await _bookRepository.DeleteAsync(bookToDelete);

        return Unit.Value;
    }
}
