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
    private readonly IAsyncRepository<Order> _orderRepository;  
    private readonly IMapper _mapper;

    public DeleteCartItemCommandHandler(
        IMapper mapper,
        ICartItemRepository cartItemRepository,
        IOrderRepository orderRepository)   
    {
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(DeleteCartitemCommand request, CancellationToken cancellationToken)
    {
        var cartItemToDelete = await _cartItemRepository.GetByIdAsync(request.CartItemId);

        if (cartItemToDelete == null)
        {
            throw new NotFoundException(nameof(CartItem), request.CartItemId);
        }

        var order = await _orderRepository.GetByIdAsync(request.CartItemId);
        if(order != null)
        {
            throw new InvalidOperationException("Cannot delete a cart item that is part of an order.");
        }   

        await _cartItemRepository.DeleteAsync(cartItemToDelete);
        return Unit.Value;
    }
}
