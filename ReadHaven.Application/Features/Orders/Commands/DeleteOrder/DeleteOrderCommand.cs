using MediatR;

namespace ReadHaven.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public DeleteOrderCommand(Guid orderId)
    {
        Id = orderId;
    }
}
