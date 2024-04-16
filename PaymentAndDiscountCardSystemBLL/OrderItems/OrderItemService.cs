using PaymentAndDiscountCardSystemDAL.Repositories.OrderItemRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;
using PaymentAndDiscountCardSystemBLL.Orders;
using PaymentAndDiscountCardSystemBLL.Products;

namespace PaymentAndDiscountCardSystemBLL.OrderItems
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderItemService(
            IOrderItemRepository orderItemRepository,
            IOrderService orderService,
            IProductService productService)
        {
            _orderItemRepository = orderItemRepository;
            _orderService = orderService;
            _productService = productService;
        }
        public async Task<bool> AddToOrder(Guid orderId, Guid productId)
        {
            var order = await _orderService.Get(orderId);

            var product = await _productService.Get(productId);

            var isAdded = await _orderItemRepository.Create(order, product);

            return isAdded;
        }

        public async Task<OrderItem> UpdateFromOrder(Guid orderItemId, int countOrderItem)
        {
            var orderItem = await _orderItemRepository.Update(orderItemId, countOrderItem);
            return orderItem;
        }
        public async Task<Guid> Delete(Guid orderItemId)
        {
            var guidDeletedOrderItem = await _orderItemRepository.Delete(orderItemId);
            return guidDeletedOrderItem;
        }
    }
}
