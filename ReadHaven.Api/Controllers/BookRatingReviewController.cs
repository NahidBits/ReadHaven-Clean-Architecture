using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHaven.Application.Features.Books.Commands.CreateBook;
using ReadHaven.Application.Features.BooksRatingReview.Commands.CreateRatingReview;

namespace ReadHaven.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class BookRatingReviewController : Controller
{
    private readonly IMediator _mediator;
    public BookRatingReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpPost("AddBookRatingReview")]
    public async Task<ActionResult<CreateRatingReviewResponse>> Create([FromBody] CreateRatingReviewCommand createRatingReviewCommand)
    {
        var response = await _mediator.Send(createRatingReviewCommand);
        return Ok(response);
    }
}
