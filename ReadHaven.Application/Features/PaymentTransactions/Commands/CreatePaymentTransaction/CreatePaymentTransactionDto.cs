using MediatR;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.PaymentTransactions.Commands.CreatePaymentTransaction;

public class CreatePaymentTransactionDto
{
    public Guid OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string TransactionId { get; set; } 
    public Status Status { get; set; }
    public decimal DisListAmount { get; set; }
    public decimal TaxAmount { get; set; }
}
