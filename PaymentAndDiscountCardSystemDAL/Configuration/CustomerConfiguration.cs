using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentAndDiscountCardSystemDAL.Entity;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemDAL.Configuration
{
    public class CustomerConfiguration// : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.
                HasMany(c => c.DiscountCards)
                .WithOne(card => card.Customer)
                .HasForeignKey(card => card.CustomerId);
        }
    }
}
