using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ReadHaven.Application.Features.Orders.Queries.GetMyOrderList;

public class GetMyOrderListQuery : IRequest<List<MyOrderListVm>>
{
    
}   