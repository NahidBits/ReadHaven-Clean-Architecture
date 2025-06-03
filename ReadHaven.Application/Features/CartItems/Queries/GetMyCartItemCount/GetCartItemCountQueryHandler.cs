using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.CartItems.Queries.GetMyCartItemCount;

public class GetCartItemCountQueryHandler : IRequestHandler<GetCartItemCountQuery, CartItemCountVm>
{
    private readonly ICartItemRepository _CartItemRepository;
    private readonly ILoggedInUserService _loggedInUserService;
    private readonly IMapper _mapper;

    public GetCartItemCountQueryHandler(IMapper mapper, ICartItemRepository CartItemRepository, ILoggedInUserService loggedInUserService)
    {
        _mapper = mapper;
        _CartItemRepository = CartItemRepository;
        _loggedInUserService = loggedInUserService;   
    }

    public async Task<CartItemCountVm> Handle(GetCartItemCountQuery request, CancellationToken cancellationToken)
    {
        var cartItemCount = await _CartItemRepository.GetCountByUserIdAsync(Guid.Parse(_loggedInUserService.UserId));

        var cartItemCountVm = new CartItemCountVm
        {
            Count = cartItemCount
        };  

        return cartItemCountVm;
    }
}
