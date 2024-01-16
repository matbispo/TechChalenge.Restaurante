
namespace Domain.Interfaces.Gateways.Order
{
    public interface IGetAllOrdersGateway
    {
        IEnumerable<Domain.Entities.Order> GetAll();
    }
}
