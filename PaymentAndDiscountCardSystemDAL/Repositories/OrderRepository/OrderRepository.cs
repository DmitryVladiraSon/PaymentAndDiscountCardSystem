using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;

namespace PaymentAndDiscountCardSystemDAL.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ILogger<OrderRepository> _logger;
        private readonly StoreDbContext _dbContext;

        public OrderRepository(ILogger<OrderRepository> logger, StoreDbContext dbContext )
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<IBaseResponse<Order>> Create(Guid customerId)
        {
            var response = new BaseResponse<Order>();
            var order = new Order(customerId);
           await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return response;
        }
    }
}
