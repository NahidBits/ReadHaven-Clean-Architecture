using FluentValidation;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Shipping address is required.")
                .MaximumLength(250).WithMessage("Shipping address must not exceed 250 characters.");

            RuleFor(x => x.ShippingCity)
                .IsInEnum().WithMessage("City must be a valid enum value.");

            RuleFor(x => x.ShippingPostalCode)
                .NotEmpty().WithMessage("Postal code is required.")
                .Matches(@"^\d{5}(-\d{4})?$").WithMessage("Postal code must be in a valid format.");

            RuleFor(x => x.ShippingCountry)
                .IsInEnum().WithMessage("Country must be a valid enum value.");

            RuleFor(x => x.ShippingContact)
                .NotEmpty().WithMessage("Contact is required.")
                .MaximumLength(50).WithMessage("Contact must not exceed 50 characters.");
        }
    }
}
