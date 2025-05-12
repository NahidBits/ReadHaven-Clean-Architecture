
using ReadHaven.Domain.Common;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Domain.Entities;

public class PaymentTransaction : BaseEntity
{
    public Guid OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string TransactionId { get; set; } = $"TXN-{DateTime.UtcNow:yyyyMMddHHmmss}-{new Random().Next(1000, 9999)}";
    public Status Status { get; set; }
    public decimal DiscountAmount { get; set; } = 10;
    public decimal TaxAmount { get; set; } = 5;
}
