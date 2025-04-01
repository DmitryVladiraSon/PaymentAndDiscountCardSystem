using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentAndDiscountCardSystemDomain.Entity.OrdersItems;
using System.Reflection.Emit;

namespace PaymentAndDiscountCardSystemDAL.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasNoKey();

            builder
        .HasOne(oi => oi.Order) 
        .WithMany(o => o.OrderItems)
        .HasForeignKey(oi => oi.OrderId);
        }
    }
}
