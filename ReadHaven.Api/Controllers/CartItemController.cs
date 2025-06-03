using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHaven.Application.Features.Books.Commands.DeleteBook;
using ReadHaven.Application.Features.Books.Queries.GetBooksList;
using ReadHaven.Application.Features.BooksRatingReview.Commands.CreateRatingReview;
using ReadHaven.Application.Features.Cartitems.Commands.CreateCartItem;
using ReadHaven.Application.Features.Cartitems.Commands.DeleteCartItem;
using ReadHaven.Application.Features.CartItems.Queries.GetMyCartItemList;
using ReadHaven.Application.Features.CartItems.Queries.GetMyCartItemCount;

namespace ReadHaven.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CartItemController : Controller
{
    private readonly IMediator _mediator;
    public CartItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AddCartItem")]
    public async Task<ActionResult<CreateCartItemResponse>> Create([FromBody] CreateCartItemCommand createCartItemCommand)
    {
        var response = await _mediator.Send(createCartItemCommand);
        return Ok(response);
    }

    [HttpGet("GetMyCartItem")]
    public async Task<ActionResult<CartItemListVm>> GetMyAllCartItem()
    {
        var dtos = await _mediator.Send(new GetCartItemListQuery());
        return Ok(dtos);
    }

    [HttpGet("GetMyCartItemCount")]
    public async Task<ActionResult<CartItemListVm>> GetMyAllCartItemCount()
    {
        var dtos = await _mediator.Send(new GetCartItemCountQuery());
        return Ok(dtos);
    }

    [HttpDelete("DeleteCartItem/{id}")]
    public async Task<IActionResult> DeleteCartItem(Guid id)
    {
        var command = new DeleteCartitemCommand { CartItemId = id };
        await _mediator.Send(command);
        return NoContent();

    }
}
