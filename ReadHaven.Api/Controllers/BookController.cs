using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHaven.Application.Features.Books.Queries;


namespace ReadHaven.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]

public class BookController : Controller
{

    private readonly IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllBooks")]
    public async Task<ActionResult<List<BookListVm>>> GetAllBooks()
    {
        var dtos = await _mediator.Send(new GetBooksListQuery());
        return Ok(dtos);
    }
}
