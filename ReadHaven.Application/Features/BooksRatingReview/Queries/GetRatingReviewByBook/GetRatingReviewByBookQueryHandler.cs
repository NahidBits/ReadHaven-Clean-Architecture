using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Features.CartItems.Queries.GetMyCartItemList;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.BooksRatingReview.Queries.GetRatingReviewByBook;

public class GetRatingReviewByBookQueryHandler : IRequestHandler<GetRatingReviewByBookQuery, List<RatingReviewVm>>
{
    private readonly IAsyncRepository<BookRatingReview> _ratingReviewRepository;
    private readonly IMapper _mapper;

    public GetRatingReviewByBookQueryHandler(IMapper mapper, IAsyncRepository<BookRatingReview> ratingReviewRepository)
    {
        _mapper = mapper;
        _ratingReviewRepository = ratingReviewRepository;
    }

    public async Task<List<RatingReviewVm>> Handle(GetRatingReviewByBookQuery request, CancellationToken cancellationToken)
    {
        var ratingReviews = await _ratingReviewRepository.ListAsync(ci => ci.BookId == request.BookId);

        return _mapper.Map<List<RatingReviewVm>>(ratingReviews);
    }
}
