using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;

namespace PaymentAndDiscountCardSystemService.Orders
{
    public interface IOrderService
    {
        Task<IBaseResponse<Guid>> Create(Guid customerId);
        Task<IBaseResponse<Order>> Get(Guid orderId);
    }
}