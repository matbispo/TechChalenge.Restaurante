using Application.Presenters.Dtos;

namespace Application.UseCases.Services.Interfaces
{
    public interface IOrderService
    {
        public string? CreateOrder(OrderDtoInput ordered);

        public IList<OrderedDtoOutput> GetAll();
    }
}
