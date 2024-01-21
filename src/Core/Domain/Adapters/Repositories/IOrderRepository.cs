using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        string? CreateOrder(Order ordered);

        IEnumerable<Order> GetAll();

        void UpdateOrderStatus(string orderId, OrderStatus orderStatus);

        OrderStatus GetOrderPaymentStatus(string orderId);
    }
}
