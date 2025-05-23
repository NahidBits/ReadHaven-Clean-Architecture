using ReadHaven.Application.Responses;

namespace ReadHaven.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderResponse : BaseResponse
{
    public CreateOrderResponse() : base()
    {
    }

    public CreateOrderDto Order { get; set; } = default!;
}
