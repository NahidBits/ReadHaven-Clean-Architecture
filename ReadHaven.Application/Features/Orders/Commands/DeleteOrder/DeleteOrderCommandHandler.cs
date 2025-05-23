using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
{
    private readonly IAsyncRepository<Order> _orderRepository;
    private readonly IMapper _mapper;

    public DeleteOrderCommandHandler(
        IMapper mapper,
        IAsyncRepository<Order> orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        
        await _orderRepository.DeleteByIdAsync(request.Id);
        return Unit.Value;
    }
}
