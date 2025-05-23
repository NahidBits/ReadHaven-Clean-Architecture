using MediatR;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.Cartitems.Commands.CreateCartItem;

public class CreateCartItemDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
