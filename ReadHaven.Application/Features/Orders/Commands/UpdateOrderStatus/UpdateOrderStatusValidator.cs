using FluentValidation;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusCommand>
{
    public UpdateOrderStatusValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order ID is required.");
        RuleFor(x => x.Status).IsInEnum().WithMessage("Invalid status.");
    }
}
