using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Orders.Queries.GetMyOrderList;

public class GetMyOrderListQueryHandler : IRequestHandler<GetMyOrderListQuery, List<MyOrderListVm>>
{
    private readonly IAsyncRepository<Order> _orderRepository;
    private readonly ILoggedInUserService _loggedInUserService;
    private readonly IMapper _mapper;

    public GetMyOrderListQueryHandler(IMapper mapper, IAsyncRepository<Order> orderRepository, ILoggedInUserService loggedInUserService)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _loggedInUserService = loggedInUserService;   
    }

    public async Task<List<MyOrderListVm>> Handle(GetMyOrderListQuery request, CancellationToken cancellationToken)
    {
        var userOrders = await _orderRepository.ListAsync(ci => ci.UserId == Guid.Parse(_loggedInUserService.UserId));

        return _mapper.Map<List<MyOrderListVm>>(userOrders);
    }
}
