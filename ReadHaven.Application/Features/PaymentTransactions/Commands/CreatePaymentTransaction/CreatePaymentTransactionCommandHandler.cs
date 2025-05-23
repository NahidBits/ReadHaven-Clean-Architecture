using AutoMapper;
using MediatR;
using ReadHaven.Application.Common.Interfaces.Security;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Features.Orders.Commands.UpdateOrderStatus;
using ReadHaven.Domain.Entities;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.PaymentTransactions.Commands.CreatePaymentTransaction;

public class CreatePaymentTransactionCommandHandler : IRequestHandler<CreatePaymentTransactionCommand, CreatePaymentTransactionResponse>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IAsyncRepository<PaymentTransaction> _PaymentTransactionRepository;  
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    private readonly IMediator _mediator;


    public CreatePaymentTransactionCommandHandler(
        IMapper mapper,
        ICartItemRepository cartItemRepository,
        ILoggedInUserService loggedInUserService,
        IAsyncRepository<PaymentTransaction> PaymentTransactionRepository,
        IJwtService jwtService,
        IOrderRepository orderRepository,
        IMediator mediator)
    {
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
        _orderRepository = orderRepository;
        _PaymentTransactionRepository = PaymentTransactionRepository;
        _jwtService = jwtService;
        _mediator = mediator;   
    }

    public async Task<CreatePaymentTransactionResponse> Handle(CreatePaymentTransactionCommand request, CancellationToken cancellationToken)
    {
        var response = new CreatePaymentTransactionResponse();

        var validator = new CreatePaymentTransactionCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        var principal = _jwtService.GetPrincipalFromToken(request.Token);
        if (principal == null)
        {
            response.Success = false;
            response.ValidationErrors = new List<string> { "Invalid or expired token." };
            return response;
        }

        var order = await _orderRepository.GetByIdAsync(request.OrderId);   
        var cartItems = await _cartItemRepository.GetSoftDeletedByOrderIdAsync(request.OrderId);

        if (order == null)
        {
            response.Success = false;
            response.ValidationErrors = new List<string> { "No order found for the Payment." };
            return response;
        }

        decimal totalAmount = cartItems.Sum(ci => ci.Price) * (1 + request.TaxAmount / 100m - request.DiscountAmount / 100m);

        var paymentTransaction = _mapper.Map<PaymentTransaction>(request);
        paymentTransaction.TotalAmount = totalAmount;

        var createdPaymentTransaction = await _PaymentTransactionRepository.AddAsync(paymentTransaction);
        response.PaymentTransaction = _mapper.Map<CreatePaymentTransactionDto>(createdPaymentTransaction);

        await _mediator.Send(new UpdateOrderStatusCommand(request.OrderId,Status.Processing), cancellationToken);
        return response;
    }
}
