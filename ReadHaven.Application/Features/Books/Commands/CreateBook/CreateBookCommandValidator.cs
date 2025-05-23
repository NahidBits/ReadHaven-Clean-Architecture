using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ReadHaven.Application.Features.Books.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.Genre)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(p => p.Image)
            .NotNull().WithMessage("Image file is required.")
            .Must(BeAValidImage).WithMessage("Only image files (.jpg, .jpeg, .png) are allowed.")
            .Must(f => f.Length <= 2 * 1024 * 1024).WithMessage("Image size must not exceed 2MB.");
    }

    private bool BeAValidImage(IFormFile? file)
    {
        if (file == null) return false;

        var permittedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        return permittedExtensions.Contains(ext);
    }
}
