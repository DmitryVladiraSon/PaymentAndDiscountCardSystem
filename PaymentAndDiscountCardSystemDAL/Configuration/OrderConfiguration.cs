using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using PaymentAndDiscountCardSystemDomain.Entity.Orders;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;
using System.Reflection.Emit;

namespace PaymentAndDiscountCardSystemDAL.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            }
    }
}
