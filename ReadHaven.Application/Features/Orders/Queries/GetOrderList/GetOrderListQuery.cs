using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ReadHaven.Application.Features.Books.Queries.GetBookDetails;

namespace ReadHaven.Application.Features.Orders.Queries.GetOrderList;

public class GetOrderListQuery : IRequest<List<OrderListVm>>
{
    
}   