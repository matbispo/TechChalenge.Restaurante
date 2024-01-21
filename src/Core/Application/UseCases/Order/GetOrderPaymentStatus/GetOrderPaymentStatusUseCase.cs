
using Domain.ValueObjects;
using Gateway.Order;
using System.ComponentModel;

namespace Application.UseCases.Order.GetOrderPaymentStatus
{
    public class GetOrderPaymentStatusUseCase : IGetOrderPaymentStatusUseCase
    {
        private readonly IOrderGateway _orderGateway;

        public GetOrderPaymentStatusUseCase(IOrderGateway orderGateway)
        {
            _orderGateway = orderGateway;
        }

        public string Execute(string? orderId)
        {
            return Enum.GetName(typeof(OrderStatus), _orderGateway.GetOrderPaymentStatus(orderId));
        }
    }
}
