
using ReadHaven.Domain.Common;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Domain.Entities;

public class PaymentTransaction : BaseEntity
{
    public Guid OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; } = Currency.USD;
    public PaymentMethod PaymentMethod { get; set; }
    public string TransactionId { get; set; } = $"TXN-{DateTime.UtcNow:yyyyMMddHHmmss}-{new Random().Next(1000, 9999)}";
    public Status Status { get; set; } = Status.Pending;
    public decimal DisListAmount { get; set; } = 10;
    public decimal TaxAmount { get; set; } = 5;
}
