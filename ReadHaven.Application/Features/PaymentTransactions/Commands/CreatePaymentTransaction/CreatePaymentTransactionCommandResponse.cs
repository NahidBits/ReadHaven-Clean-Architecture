using ReadHaven.Application.Responses;

namespace ReadHaven.Application.Features.PaymentTransactions.Commands.CreatePaymentTransaction;

public class CreatePaymentTransactionResponse : BaseResponse
{
    public CreatePaymentTransactionResponse() : base()
    {
    }

    public CreatePaymentTransactionDto PaymentTransaction { get; set; } = default!;
}
