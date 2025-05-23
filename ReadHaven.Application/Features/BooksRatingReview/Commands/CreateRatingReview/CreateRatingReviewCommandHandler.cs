using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Contracts.Services;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.BooksRatingReview.Commands.CreateRatingReview;

public class CreateCartItemCommandHandler : IRequestHandler<CreateRatingReviewCommand, CreateRatingReviewResponse>
{
    private readonly IAsyncRepository<BookRatingReview> _ratingReviewRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly ILoggedInUserService _loggedInUserService;


    public CreateCartItemCommandHandler(
        IMapper mapper,
        IAsyncRepository<BookRatingReview> ratingReviewRepository,
        IBookRepository bookRepository,
        ILoggedInUserService loggedInUserService)
    {
        _mapper = mapper;
        _ratingReviewRepository = ratingReviewRepository;
        _bookRepository = bookRepository;
        _loggedInUserService = loggedInUserService;
    }

    public async Task<CreateRatingReviewResponse> Handle(CreateRatingReviewCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateRatingReviewResponse();

        var validator = new CreateRatingReviewCommandValidator(_bookRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        var review = _mapper.Map<BookRatingReview>(request);
        review.UserId = Guid.Parse(_loggedInUserService.UserId);

        var newReview = await _ratingReviewRepository.AddAsync(review);
        response.RatingReview = _mapper.Map<CreateRatingReviewDto>(newReview);

        return response;
    }
}
