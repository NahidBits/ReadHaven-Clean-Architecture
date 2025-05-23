using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.Orders.Queries.GetMyOrderList;

public class MyOrderListVm
{
    public Guid Id { get; set; }    
    public DateTime OrderDate { get; set; }
    public Status Status { get; set; }
    public string ShippingAddress { get; set; }
    public City ShippingCity { get; set; }
    public string ShippingPostalCode { get; set; }
    public Country ShippingCountry { get; set; }
    public string ShippingContact { get; set; }
    public DateTime PossibleDayToShip { get; set; }
}
