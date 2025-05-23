using MediatR;
using Microsoft.AspNetCore.Http;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.PaymentTransactions.Commands.CreatePaymentTransaction;

public class CreatePaymentTransactionCommand : IRequest<CreatePaymentTransactionResponse>
{
    public Guid OrderId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal DiscountAmount { get; set; } = 10;
    public decimal TaxAmount { get; set; } = 5;
    public string Token { get; set; }
}
