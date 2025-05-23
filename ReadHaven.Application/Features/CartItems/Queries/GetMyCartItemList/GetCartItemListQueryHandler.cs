using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.CartItems.Queries.GetMyCartItemList;

public class GetCartItemListQueryHandler : IRequestHandler<GetCartItemListQuery, List<CartItemListVm>>
{
    private readonly IAsyncRepository<CartItem> _CartItemRepository;
    private readonly ILoggedInUserService _loggedInUserService;
    private readonly IMapper _mapper;

    public GetCartItemListQueryHandler(IMapper mapper, IAsyncRepository<CartItem> CartItemRepository, ILoggedInUserService loggedInUserService)
    {
        _mapper = mapper;
        _CartItemRepository = CartItemRepository;
        _loggedInUserService = loggedInUserService;   
    }

    public async Task<List<CartItemListVm>> Handle(GetCartItemListQuery request, CancellationToken cancellationToken)
    {
        var userCartItems = await _CartItemRepository.ListAsync(ci => ci.UserId == Guid.Parse(_loggedInUserService.UserId));

        return _mapper.Map<List<CartItemListVm>>(userCartItems);
    }
}
