
using ReadHaven.Domain.Common;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public Status Status { get; set; } = Status.Pending;
    public string ShippingAddress { get; set; }
    public City City { get; set; }
    public string PostalCode { get; set; }
    public Country Country { get; set; }
    public string Contact { get; set; }
    public DateTime PossibleDayToShip { get; set; }
}