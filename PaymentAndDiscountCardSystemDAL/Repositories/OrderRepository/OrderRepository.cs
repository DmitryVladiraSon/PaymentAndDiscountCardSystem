﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public async Task<Guid> Create(Guid customerId)
        {
            var order = new Order(customerId);
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order.OrderId;
        }

        public async Task<Order> Get(Guid orderId)
        {
            var order = await _dbContext.Orders
                .Where(o => o.OrderId == orderId)
                .Include(o => o.Customer)
                .Include(oi => oi.OrderItems)
                    .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _dbContext.Orders
                .Include(o => o.Customer)
                .Include(oi => oi.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }
    }
}
