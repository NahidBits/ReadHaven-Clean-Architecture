using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Features.Books.Queries.GetBookDetails;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.CartItems.Queries.GetMyCartItemList;

public class GetCartItemListQueryHandler : IRequestHandler<GetCartItemListQuery, List<CartItemListVm>>
{
    private readonly IAsyncRepository<CartItem> _CartItemRepository;
    private readonly IAsyncRepository<Book> _bookRepository;
    private readonly ILoggedInUserService _loggedInUserService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetCartItemListQueryHandler(IMapper mapper, IAsyncRepository<CartItem> CartItemRepository, ILoggedInUserService loggedInUserService, IMediator mediator, IAsyncRepository<Book> bookRepository   )
    {
        _mapper = mapper;
        _CartItemRepository = CartItemRepository;
        _loggedInUserService = loggedInUserService;
        _mediator = mediator;
        _bookRepository = bookRepository;
    }

    public async Task<List<CartItemListVm>> Handle(GetCartItemListQuery request, CancellationToken cancellationToken)
    {
        var userCartItems = await _CartItemRepository.ListAsync(ci => ci.UserId == Guid.Parse(_loggedInUserService.UserId));
        var bookIds = userCartItems.Select(ci => ci.BookId).Distinct().ToList();
        var books = await _bookRepository.ListAsync(b => bookIds.Contains(b.Id));



        var cartItemVms = userCartItems.Select(ci => {
            var book = books.FirstOrDefault(b => b.Id == ci.BookId);
            return new CartItemListVm
            {
                Id = ci.Id,
                BookId = ci.BookId,
                Quantity = ci.Quantity,
                Price = ci.Price,
                BookTitle = book.Title,
                ImagePath = book.ImagePath
            };
        }).ToList();

        return cartItemVms;
    }
}
