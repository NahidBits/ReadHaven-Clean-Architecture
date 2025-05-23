using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Features.CartItems.Commands.AssignCartItemsToOrder;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, Unit>
{
    private readonly IAsyncRepository<Order> _orderRepository;

    public UpdateOrderStatusHandler(IAsyncRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);

        if (order == null)
            throw new Exception("Order not found.");

        order.Status = request.Status;

        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}
