using MediatR;

namespace ReadHaven.Application.Features.Cartitems.Commands.DeleteCartItem;

public class DeleteCartitemCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public DeleteCartitemCommand(Guid userId)
    {
        UserId = userId;
    }
}
