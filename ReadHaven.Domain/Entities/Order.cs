
using ReadHaven.Domain.Common;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public Status Status { get; set; } = Status.Pending;
    public string ShippingAddress { get; set; }
    public City ShippingCity { get; set; }
    public string ShippingPostalCode { get; set; }
    public Country ShippingCountry { get; set; }
    public string ShippingContact { get; set; }
    public DateTime PossibleDayToShip { get; set; } = DateTime.Now.AddDays(3);  
}