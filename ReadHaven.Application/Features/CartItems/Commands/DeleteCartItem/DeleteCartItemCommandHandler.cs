using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Exceptions;
using ReadHaven.Domain.Entities;
using Microsoft.AspNetCore.Hosting;

namespace ReadHaven.Application.Features.Cartitems.Commands.DeleteCartItem;

public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartitemCommand, Unit>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public DeleteCartItemCommandHandler(
        IMapper mapper,
        ICartItemRepository cartItemRepository)
    {
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
    }

    public async Task<Unit> Handle(DeleteCartitemCommand request, CancellationToken cancellationToken)
    {
        var cartItemToDelete = await _cartItemRepository.GetByUserIdAsync(request.UserId);

        if (cartItemToDelete == null)
        {
            throw new NotFoundException(nameof(CartItem), request.UserId);
        }

        await _cartItemRepository.DeleteRangeAsync(cartItemToDelete);
        return Unit.Value;
    }
}
