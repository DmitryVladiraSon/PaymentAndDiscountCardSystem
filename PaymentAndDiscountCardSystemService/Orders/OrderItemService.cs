using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;

namespace PaymentAndDiscountCardSystemService.Orders
{
    internal class OrderItemService
    {
        public async Task<IBaseResponse<Order>> AddToOrder(Order order, OrderItem orderItem)
        {
            var response = new BaseResponse<Order>();
            order.orderItems.Add(orderItem);

            return response;
        }
    }
}
