
namespace Domain.Interfaces.Gateways.Order
{
    public interface IGetAllOrdersGateway
    {
        IList<Domain.Entities.Order> GetAll();
    }
}
