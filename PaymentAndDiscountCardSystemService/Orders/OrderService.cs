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

        public async Task<Guid> Create(Guid customerId)
        {
            var order = await _orderRepository.Create(customerId);
            return order;
        }
        public async Task<Order> Get(Guid orderId)
        {
            var order = await _orderRepository.Get(orderId);
            
            return order;
        }

        public async Task<List<Order>> GetFromCustomer(Guid customerId)
        {
            var orders = await _orderRepository.GetAll();
            var customersOrders = orders
                .Where(o => o.CustomerId == customerId)
                .ToList();
            return customersOrders;
        }

    }
}
