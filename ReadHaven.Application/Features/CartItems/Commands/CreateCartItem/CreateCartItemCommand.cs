using MediatR;
using Microsoft.AspNetCore.Http;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.Cartitems.Commands.CreateCartItem;

public class CreateCartItemCommand : IRequest<CreateCartItemResponse>
{
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
}
