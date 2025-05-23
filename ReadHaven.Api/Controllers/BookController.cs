using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHaven.Application.Features.Books.Commands.CreateBook;
using ReadHaven.Application.Features.Books.Commands.DeleteBook;
using ReadHaven.Application.Features.Books.Commands.UpdateBook;
using ReadHaven.Application.Features.Books.Queries;
using ReadHaven.Application.Features.Books.Queries.GetBookDetails;
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

    [AllowAnonymous]
    [HttpGet("GetAllBooks")]
    public async Task<ActionResult<List<BookListVm>>> GetAllBooks()
    {
        var dtos = await _mediator.Send(new GetBooksListQuery());
        return Ok(dtos);
    }

    [AllowAnonymous]
    [HttpGet("GetBookDetails/{id}")]
    public async Task<ActionResult<BookDetailsVm>> GetBookDetails(Guid id)
    {
        var query = new GetBookDetailsQuery { BookId = id };
        var dto = await _mediator.Send(query);
        return Ok(dto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("AddBook")]
    public async Task<ActionResult<CreateBookCommandResponse>>  Create([FromForm] CreateBookCommand createBookCommand)
    {
        var response = await _mediator.Send(createBookCommand);
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("UpdateBook")]
    public async Task<ActionResult> Update([FromForm] UpdateBookCommand updateBookCommand)
    {
        await _mediator.Send(updateBookCommand);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteBook/{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleteBookCommand = new DeleteBookCommand() { BookId = id };
        await _mediator.Send(deleteBookCommand);
        return NoContent();
    }
}
