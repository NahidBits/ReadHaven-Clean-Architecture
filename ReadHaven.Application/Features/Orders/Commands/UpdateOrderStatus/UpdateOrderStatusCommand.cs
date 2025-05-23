using MediatR;
using Microsoft.AspNetCore.Http;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommand : IRequest<Unit>
{
    public Guid OrderId { get; set; }
    public Status Status { get; set; }

    public UpdateOrderStatusCommand(Guid orderId,Status status)
    {
        OrderId = orderId;
        Status = status;    
    }
}
