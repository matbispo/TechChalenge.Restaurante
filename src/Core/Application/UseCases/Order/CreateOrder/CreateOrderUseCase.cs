using Application.Presenters.Dtos;
using Domain.Interfaces.Gateways.Order;

namespace Application.UseCases.Order.CreateOrder
{
    internal class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly ICreateOrderGateway _createOrderGateway;

        public string? CreateOrder(OrderDtoInput orderInput)
        {
            // validation

            var order = new Domain.Entities.Order(orderInput.CustomerId);
            order.Products = _createOrderGateway.GetProductsById(orderInput.Products);
            order.SumTotalPrice();

            return _createOrderGateway.CreateOrder(order);
        }
    }
}
