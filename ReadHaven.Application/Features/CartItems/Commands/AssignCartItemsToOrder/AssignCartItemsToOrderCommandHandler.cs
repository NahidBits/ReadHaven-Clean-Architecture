using MediatR;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Features.CartItems.Commands.AssignCartItemsToOrder;
using System.Threading;
using System.Threading.Tasks;

namespace ReadHaven.Application.Features.Cartitems.Commands.AssignCartItemsToOrder
{
    public class AssignCartItemsToOrderCommandHandler : IRequestHandler<AssignCartItemsToOrderCommand, Unit>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public AssignCartItemsToOrderCommandHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Unit> Handle(AssignCartItemsToOrderCommand request, CancellationToken cancellationToken)
        {
            var cartItems = await _cartItemRepository.GetByUserIdAsync(request.UserId);

            foreach (var item in cartItems)
            {
                item.OrderId = request.OrderId;
                item.IsDeleted = true;

                await _cartItemRepository.UpdateAsync(item);
            }

            return Unit.Value;
        }
    }
}
