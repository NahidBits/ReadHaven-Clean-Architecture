using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHaven.Application.Features.Books.Queries.GetBookDetails;
using ReadHaven.Application.Features.Orders.Commands.CreateOrder;
using ReadHaven.Application.Features.Orders.Commands.UpdateOrderStatus;
using ReadHaven.Application.Features.Orders.Queries.GetMyOrderList;
using ReadHaven.Application.Features.Orders.Queries.GetOrderList;

namespace ReadHaven.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;
    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("AddOrder")]
    public async Task<ActionResult<CreateOrderResponse>> Create([FromBody] CreateOrderCommand createOrderCommand)
    {
        var response = await _mediator.Send(createOrderCommand);
        return Ok(response);
    }

    [HttpGet("GetMyOrder")]
    public async Task<ActionResult<MyOrderListVm>> GetMyOrder()
    {
        var dtos = await _mediator.Send(new GetMyOrderListQuery());
        return Ok(dtos);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetAllOrder")]
    public async Task<ActionResult<OrderListVm>> GetAllOrder()
    {
        var dtos = await _mediator.Send(new GetOrderListQuery());
        return Ok(dtos);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("Updatestatus")]
    public async Task<IActionResult> UpdateStatus([FromBody] UpdateOrderStatusCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
