using FluentValidation;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;

namespace ReadHaven.Application.Features.Cartitems.Commands.CreateCartItem;

    public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
    {
        public CreateCartItemCommandValidator(IBookRepository bookRepository)
        {
            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage("Book ID is required.");

            RuleFor(x => x.BookId)
            .MustAsync(async (bookId, cancellation) =>
                    await bookRepository.ExistsAsync(bookId))
                .WithMessage("Book with the specified ID does not exist.");

            RuleFor(x => x.Quantity)
             .GreaterThan(0).WithMessage("Quantity must be at least 1.")
             .LessThanOrEqualTo(100).WithMessage("Quantity must not exceed 100.");
    }
    }
