using Application.UseCases.Order.UpdatePaymentOrderStatus;
using Domain.Interfaces.Gateways.Order;
using Domain.ValueObjects;
using Gateway.Order;

namespace Application.UseCases.Order.UpdateOrderStatus
{
    internal class UpdateOrderStatusUseCase : IUpdateOrderStatusUseCase
    {
        private readonly IOrderGateway _orderGateway;

        public UpdateOrderStatusUseCase(IOrderGateway orderGateway)
        {
            _orderGateway = orderGateway;
        }

        public void Execute(string orderId, OrderStatus orderStatus)
        {
            _orderGateway.UpdateOrderStatus(orderId, orderStatus);
        }
    }
}
