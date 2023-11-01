using Application.Dtos;

namespace Application.Services.Interfaces
{
    public interface IOrderService
    {
        public string? CreateOrder(OrderDtoInput ordered);

        public IList<OrderedDtoOutput> GetAll();
    }
}
