using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHaven.Application.Features.PaymentTransactions.Commands.CreatePaymentTransaction;

namespace ReadHaven.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PaymentController : Controller
{
    private readonly IMediator _mediator;
    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("AddPaymentTransaction")]
    public async Task<ActionResult<CreatePaymentTransactionResponse>> Create([FromBody] CreatePaymentTransactionCommand createPaymentTransactionCommand)
    {
        var response = await _mediator.Send(createPaymentTransactionCommand);
        return Ok(response);
    }
}
