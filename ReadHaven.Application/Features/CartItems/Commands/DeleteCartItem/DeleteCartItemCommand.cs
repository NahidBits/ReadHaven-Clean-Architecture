using MediatR;

namespace ReadHaven.Application.Features.Cartitems.Commands.DeleteCartItem;

public class DeleteCartitemCommand : IRequest<Unit>
{
    public Guid CartItemId { get; set; }
}
