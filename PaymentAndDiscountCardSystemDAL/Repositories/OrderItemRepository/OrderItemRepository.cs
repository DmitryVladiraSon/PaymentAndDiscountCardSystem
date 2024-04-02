
using Microsoft.EntityFrameworkCore;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;
using PaymentAndDiscountCardSystemDomain.Entity.Products;

namespace PaymentAndDiscountCardSystemDAL.Repositories.OrderItemRepository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrderItemRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Order order, Product product)
        {
            var orderItem = new OrderItem(order, product, 1);
            await _dbContext.OrdersItems.AddAsync(orderItem);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<OrderItem> Update(Guid orderItemId, int countOrderItem)
        {
            await _dbContext.OrdersItems
                .Where(oi => oi.Id == orderItemId)
                .ExecuteUpdateAsync(s => s
                .SetProperty(oi => oi.CountItems, countOrderItem));

            return await _dbContext.OrdersItems
                .Where(oi => oi.Id == oi.OrderId)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid> Delete(Guid orderItemId)
        {
            await _dbContext.OrdersItems
                .Where(oi => oi.Id == orderItemId)
                .ExecuteDeleteAsync();

            return orderItemId;
        }
    }
}
