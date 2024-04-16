
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemDomain.Entity.Cards
{
    public abstract class DiscountCard
    {
        public DiscountCard()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now.ToUniversalTime();
        }
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int DiscountRate { get; protected set; }
        public DiscountCardType Type { get; protected set; }

        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }

    }
}
