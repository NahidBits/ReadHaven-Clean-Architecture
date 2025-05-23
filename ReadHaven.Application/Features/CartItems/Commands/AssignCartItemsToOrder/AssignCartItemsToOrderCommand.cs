using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ReadHaven.Application.Features.CartItems.Commands.AssignCartItemsToOrder;

public class AssignCartItemsToOrderCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }

    public AssignCartItemsToOrderCommand(Guid userId, Guid orderId)
    {
        UserId = userId;
        OrderId = orderId;
    }
}