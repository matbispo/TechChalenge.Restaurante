using Application.Presenters.Dtos;
using Application.UseCases.Services.Interfaces;
using Core.Domain.Entities;
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



        
        }
    }
}
