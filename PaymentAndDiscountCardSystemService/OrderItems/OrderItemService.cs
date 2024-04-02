using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDAL.Repositories.OrderItemRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;
using PaymentAndDiscountCardSystemService.Orders;
using PaymentAndDiscountCardSystemService.Products;

namespace PaymentAndDiscountCardSystemService.OrderItems
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
        public async Task<IBaseResponse<Order>> AddToOrder(Guid orderId, Guid productId)
        {
            var response = new BaseResponse<Order>();

            var orderResponse = await _orderService.Get(orderId);
            var order = orderResponse.Data;

            var productResponse = await _productService.Get(productId);
            var product = productResponse.Data;

            await _orderItemRepository.Create(order, product);

            return response;
        }

        public async Task<IBaseResponse<OrderItem>> UpdateFromOrder(Guid orderItemId, int countOrderItem)
        {
            var response = new BaseResponse<OrderItem>();
            var orderItem = await _orderItemRepository.Update(orderItemId, countOrderItem);
            response.Data = orderItem;
            return response;
        }
        public async Task<IBaseResponse<Guid>> Delete(Guid orderItemId)
        {
            var response = new BaseResponse<Guid>();
            var idDeletedItem = await _orderItemRepository.Delete(orderItemId);
            response.Data = idDeletedItem;
            return response;
        }
    }
}
