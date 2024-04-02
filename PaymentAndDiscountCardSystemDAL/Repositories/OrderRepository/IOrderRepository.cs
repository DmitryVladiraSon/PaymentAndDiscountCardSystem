using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;

namespace PaymentAndDiscountCardSystemDAL.Repositories.OrderRepository
{
    public interface IOrderRepository 
    {
        Task<Guid> Create(Guid customerId);
        Task<Order> Get(Guid orderId);
    }
}
