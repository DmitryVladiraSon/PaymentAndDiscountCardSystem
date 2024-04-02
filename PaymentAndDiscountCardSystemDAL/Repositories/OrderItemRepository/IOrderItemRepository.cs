using PaymentAndDiscountCardSystemDomain.Entity.Orders;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;
using PaymentAndDiscountCardSystemDomain.Entity.Products;

namespace PaymentAndDiscountCardSystemDAL.Repositories.OrderItemRepository
{
    public interface IOrderItemRepository
    {
        Task<bool> Create(Order order, Product product);
        Task<Guid> Delete(Guid orderItemId);
        Task<OrderItem> Update(Guid orderItemId, int countOrderItem);
    }
}