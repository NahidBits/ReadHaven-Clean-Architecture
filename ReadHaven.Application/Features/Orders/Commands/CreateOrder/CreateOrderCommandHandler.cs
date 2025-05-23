using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Features.CartItems.Commands.AssignCartItemsToOrder;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IAsyncRepository<Order> _orderRepository;  
    private readonly IMapper _mapper;
    private readonly ILoggedInUserService _loggedInUserService;
    private readonly IMediator _mediator;


    public CreateOrderCommandHandler(
        IMapper mapper,
        ICartItemRepository cartItemRepository,
        ILoggedInUserService loggedInUserService,
        IAsyncRepository<Order> orderRepository,
        IMediator mediator)
    {
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
        _loggedInUserService = loggedInUserService;
        _orderRepository = orderRepository;
        _mediator = mediator;   
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateOrderResponse();

        var validator = new CreateOrderCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        var userId = Guid.Parse(_loggedInUserService.UserId);
        if (!(await _cartItemRepository.ExistsAsync(userId)))
        {
            response.Success = false;
            response.ValidationErrors = new List<string> { "No cart items found for the user." };
            return response;
        }

        var order = _mapper.Map<Order>(request);
        order.UserId = userId;

        try
        {
            var createdOrder = await _orderRepository.AddAsync(order);
            response.Order = _mapper.Map<CreateOrderDto>(createdOrder);
            await _mediator.Send(new AssignCartItemsToOrderCommand(userId, createdOrder.Id), cancellationToken);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.ValidationErrors = new List<string> { ex.Message, ex.InnerException?.Message };
            return response;
        }

        
        return response;
    }
}
