using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;

namespace PaymentAndDiscountCardSystemBLL.OrderItems
{
    public interface IOrderItemService
    {
        Task<bool> AddToOrder(Guid orderId, Guid productId);
        Task<Guid> Delete(Guid orderItemId);
        Task<OrderItem> UpdateFromOrder(Guid orderItemId, int countOrderItem);
    }
}