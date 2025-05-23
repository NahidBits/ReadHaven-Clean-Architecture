using MediatR;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderDto
{
    public DateTime OrderDate { get; set; }
    public Status Status { get; set; }
    public string ShippingAddress { get; set; }
    public City City { get; set; }
    public string ShippingPostalCode { get; set; }
    public Country ShippingCountry { get; set; }
    public string ShippingContact { get; set; }
    public DateTime PossibleDayToShip { get; set; }
}
