using MediatR;
using Microsoft.AspNetCore.Http;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<CreateOrderResponse>
{
    public string ShippingAddress { get; set; }
    public City ShippingCity { get; set; }
    public string ShippingPostalCode { get; set; }
    public Country ShippingCountry { get; set; }
    public string ShippingContact { get; set; }
}
