
using Domain.ValueObjects;

namespace Application.UseCases.Order.UpdatePaymentOrderStatus
{
    public interface IUpdateOrderStatusUseCase
    {
        void Execute(string orderId, OrderStatus orderStatus);
    }
}
