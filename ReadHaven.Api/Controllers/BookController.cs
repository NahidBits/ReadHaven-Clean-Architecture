using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReadHaven.Application.Features.Books.Commands.CreateBook;
using ReadHaven.Application.Features.Books.Queries;
using ReadHaven.Application.Features.Books.Queries.GetBooksList;


namespace ReadHaven.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : Controller
{
    
    private readonly IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name="GetAllBooks")]
    public async Task<ActionResult<List<BookListVm>>> GetAllBooks()
    {
        var dtos = await _mediator.Send(new GetBooksListQuery());
        return Ok(dtos);
    }
}
