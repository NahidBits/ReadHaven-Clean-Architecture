using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Contracts.Services;
using ReadHaven.Application.Features.Books.Commands.CreateBook;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Cartitems.Commands.CreateCartItem;

public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, CreateCartItemResponse>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly ILoggedInUserService _loggedInUserService;


    public CreateCartItemCommandHandler(
        IMapper mapper,
        ICartItemRepository cartItemRepository,
        IBookRepository bookRepository,
        IFileService fileService,
        ILoggedInUserService loggedInUserService)
    {
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
        _bookRepository = bookRepository;
        _fileService = fileService;
        _loggedInUserService = loggedInUserService;
    }

    public async Task<CreateCartItemResponse> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateCartItemResponse();

        var validator = new CreateCartItemCommandValidator(_bookRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        var userId = Guid.Parse(_loggedInUserService.UserId);
        var book = await _bookRepository.GetByIdAsync(request.BookId);

        var existingItem = await _cartItemRepository.GetByUserAndBookAsync(userId, request.BookId);

        if (existingItem != null)
        {
            existingItem.Quantity += request.Quantity;
            existingItem.Price = book.Price * existingItem.Quantity;


            await _cartItemRepository.UpdateAsync(existingItem);
            response.CartItem = _mapper.Map<CreateCartItemDto>(existingItem);
        }
        else
        {
            var newCartItem = new CartItem
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                BookId = request.BookId,
                Quantity = request.Quantity,
                Price = book.Price * request.Quantity
            };

            var createdCartItem = await _cartItemRepository.AddAsync(newCartItem);
            response.CartItem = _mapper.Map<CreateCartItemDto>(createdCartItem);
        }

        return response;
    }
}
