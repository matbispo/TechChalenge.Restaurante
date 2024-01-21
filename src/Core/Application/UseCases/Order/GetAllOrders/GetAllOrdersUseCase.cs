using Application.Presenters.Dtos;
using Domain.Interfaces.Gateways.Order;

namespace Application.UseCases.Order.GetAllOrders
{
    internal class GetAllOrdersUseCase : IGetAllOrdersUseCase
    {
        private readonly IGetAllOrdersGateway _getAllOrdersGateway;

        public GetAllOrdersUseCase(IGetAllOrdersGateway getAllOrdersGateway)
        {
            _getAllOrdersGateway = getAllOrdersGateway;
        }

        public IList<OrderedDtoOutput> GetAll()
        {
            var orders = _getAllOrdersGateway.GetAll();

            var ordersOutput = new List<OrderedDtoOutput>();

            foreach (var item in orders)
            {
                ordersOutput.Add(new OrderedDtoOutput
                {
                    CustomerId = item.CustomerId,
                    OrderId = new Guid(item?.OrderId),
                    OrderStatus = item.OrderStatus,
                    RequestDate = item.RequestDate,
                    TotalPrice = item.TotalPrice,
                    Products = item.Products
                });
            }

            return ordersOutput;
        }
    }
}
