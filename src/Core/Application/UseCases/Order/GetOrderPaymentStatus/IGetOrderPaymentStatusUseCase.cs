
namespace Application.UseCases.Order.GetOrderPaymentStatus
{
    public interface IGetOrderPaymentStatusUseCase
    {
        string Execute(string orderId);
    }
}
