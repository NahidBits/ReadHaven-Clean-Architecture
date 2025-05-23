using ReadHaven.Application.Responses;

namespace ReadHaven.Application.Features.Cartitems.Commands.CreateCartItem;

public class CreateCartItemResponse : BaseResponse
{
    public CreateCartItemResponse() : base()
    {
    }

    public CreateCartItemDto CartItem { get; set; } = default!;
}
