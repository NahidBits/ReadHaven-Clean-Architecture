using FluentValidation;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;

namespace ReadHaven.Application.Features.BooksRatingReview.Commands.CreateRatingReview
{
    public class CreateRatingReviewCommandValidator : AbstractValidator<CreateRatingReviewCommand>
    {
        public CreateRatingReviewCommandValidator(IBookRepository bookRepository)
        {
            RuleFor(x => x.ReviewText)
                .NotEmpty().WithMessage("Review text is required.")
                .MaximumLength(1000).WithMessage("Review text must not exceed 1000 characters.");

            RuleFor(x => x.Rating)
                .IsInEnum().WithMessage("Rating must be a valid enum value.");

            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage("Book ID is required.");

            RuleFor(x => x.BookId)
            .MustAsync(async (bookId, cancellation) =>
                    await bookRepository.ExistsAsync(bookId))
                .WithMessage("Book with the specified ID does not exist.");
        }
    }
}
