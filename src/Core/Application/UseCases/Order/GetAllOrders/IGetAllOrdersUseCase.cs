
using Application.Presenters.Dtos;

namespace Application.UseCases.Order.GetAllOrders
{
    public interface IGetAllOrdersUseCase
    {
        IList<OrderedDtoOutput> GetAll();
    }
}
