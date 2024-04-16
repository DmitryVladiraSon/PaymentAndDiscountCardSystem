using PaymentAndDiscountCardSystemDomain.Entity.Orders;

namespace PaymentAndDiscountCardSystemBLL.Orders
{
    public interface IOrderService
    {
        Task<Guid> Create(Guid customerId);
        Task<Order> Get(Guid orderId);
        Task<List<Order>> GetFromCustomer(Guid customerId);
    }
}