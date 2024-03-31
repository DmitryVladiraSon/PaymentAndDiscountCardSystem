using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;

namespace PaymentAndDiscountCardSystemDAL.Configuration
{
    public class CardConfiguration// : IEntityTypeConfiguration<DiscountCard>
    {
        public void Configure(EntityTypeBuilder<DiscountCard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Type)
                    .IsRequired();
        }
    }
}
