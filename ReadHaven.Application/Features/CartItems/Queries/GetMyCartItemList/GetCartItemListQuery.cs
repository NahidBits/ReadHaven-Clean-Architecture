using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ReadHaven.Application.Features.Books.Queries.GetBookDetails;

namespace ReadHaven.Application.Features.CartItems.Queries.GetMyCartItemList;

public class GetCartItemListQuery : IRequest<List<CartItemListVm>>
{
    
}   