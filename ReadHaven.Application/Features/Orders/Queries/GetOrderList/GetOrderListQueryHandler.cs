using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Orders.Queries.GetOrderList;

public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderListVm>>
{
    private readonly IAsyncRepository<Order> _OrderRepository;
    private readonly IMapper _mapper;

    public GetOrderListQueryHandler(IMapper mapper, IAsyncRepository<Order> OrderRepository)
    {
        _mapper = mapper;
        _OrderRepository = OrderRepository; 
    }

    public async Task<List<OrderListVm>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        var userOrders = await _OrderRepository.ListAllAsync();

        return _mapper.Map<List<OrderListVm>>(userOrders);
    }
}
