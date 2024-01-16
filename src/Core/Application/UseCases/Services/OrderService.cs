using Application.Presenters.Dtos;
using Application.UseCases.Services.Interfaces;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderedRepository;

        private readonly IproductRepository _productRepository;

        public OrderService(IOrderRepository orderedRepository, IproductRepository productRepository)
        {
            _orderedRepository = orderedRepository;
            _productRepository = productRepository;
        }

        public string? CreateOrder(OrderDtoInput ordered)
        {
            throw new NotImplementedException();
        }

        public IList<OrderedDtoOutput> GetAll()
        {
            throw new NotImplementedException();
        }
    }   
}
