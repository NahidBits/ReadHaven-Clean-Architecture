using FluentValidation;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.PaymentTransactions.Commands.CreatePaymentTransaction
{
    public class CreatePaymentTransactionCommandValidator : AbstractValidator<CreatePaymentTransactionCommand>
    {
        public CreatePaymentTransactionCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("Order ID is required.");

            RuleFor(x => x.PaymentMethod)
                .IsInEnum().WithMessage("Payment method must be a valid enum value.");

            RuleFor(x => x.DiscountAmount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount amount cannot be negative.");

            RuleFor(x => x.TaxAmount)
                .GreaterThanOrEqualTo(0).WithMessage("Tax amount cannot be negative.");
        }
    }
}
