using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    internal class OrderedService : IOrderService
    {
        private readonly IOrderedRepository _orderedRepository;

        private readonly IproductRepository _productRepository;

        public OrderedService(IOrderedRepository orderedRepository, IproductRepository productRepository)
        {
            _orderedRepository = orderedRepository;
            _productRepository = productRepository;
        }

        public string? CreateOrder(OrderDtoInput orderedInput)
        {
            var order = new Ordered(orderedInput.CustomerId);
            order.Products = _productRepository.GetProductsById(orderedInput.Products);
            order.SumTotalPrice();

            return _orderedRepository.CreateOrder(order);
        }

        public IList<OrderedDtoOutput> GetAll()
        {
            var orders = _orderedRepository.GetAll();

            var ordersOutput = new List<OrderedDtoOutput>();

            foreach (var item in orders)
            {
                ordersOutput.Add(new OrderedDtoOutput
                {
                    CustomerId = item.Customer.CustomerId,
                    OrderedId = new Guid(item?.OrderedId),
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
