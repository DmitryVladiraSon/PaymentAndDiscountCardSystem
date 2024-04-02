using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;

namespace PaymentAndDiscountCardSystemService.OrderItems
{
    public interface IOrderItemService
    {
        Task<IBaseResponse<Order>> AddToOrder(Guid orderId, Guid productId);
        Task<IBaseResponse<Guid>> Delete(Guid orderItemId);
        Task<IBaseResponse<OrderItem>> UpdateFromOrder(Guid orderItemId, int countOrderItem);
    }
}