
using Application.Presenters.Dtos;

namespace Application.UseCases.Order.CreateOrder
{
    public interface ICreateOrderUseCase
    {
        string? CreateOrder(OrderDtoInput orderInput);
    }
}
