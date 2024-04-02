using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDAL.Repositories.OrderRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;

namespace PaymentAndDiscountCardSystemService.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IBaseResponse<Guid>> Create(Guid customerId)
        {
            var response = new BaseResponse<Guid>();
            var order = await _orderRepository.Create(customerId);
            response.Data = order;

            return response;
        }
        public async Task<IBaseResponse<Order>> Get(Guid orderId)
        {
            var response = new BaseResponse<Order>();
            var order = await _orderRepository.Get(orderId);
            response.Data = order;

            return response;
        }


    }
}
